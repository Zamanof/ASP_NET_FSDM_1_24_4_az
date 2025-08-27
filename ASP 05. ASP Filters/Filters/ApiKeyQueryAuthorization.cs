using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace ASP_05._ASP_Filters.Filters;

public class ApiKeyQueryAuthorization : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var isAuthorized = context
                                  .HttpContext
                                  .Request
                                  .Query
                                  .Any(q=> q.Key=="apiKey" && q.Value=="123456");
        if (!isAuthorized)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}
