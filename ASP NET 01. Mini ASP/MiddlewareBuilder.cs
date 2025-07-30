public class MiddlewareBuilder
{
    private Stack<Type> middlewares = new();
    public void Use<T>() where T : IMiddleware
    {
        middlewares.Push(typeof(T));
    }
    public HttpHandler Build()
    {
        HttpHandler handler = context => context.Response.Close();
        while (middlewares.Count != 0)
        {
            var midleware = middlewares.Pop();
            IMiddleware? middleWare = Activator.CreateInstance(midleware) as IMiddleware;
            middleWare!.Next = handler;
            handler = middleWare.Handle;
        }
        return handler;
    }

}