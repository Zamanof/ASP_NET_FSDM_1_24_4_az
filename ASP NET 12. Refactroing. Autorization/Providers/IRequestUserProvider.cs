namespace ASP_NET_12._Refactroing._Autorization.Providers;
/// <summary>
/// 
/// </summary>
public interface IRequestUserProvider
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    UserInfo? GetUserInfo();
}
