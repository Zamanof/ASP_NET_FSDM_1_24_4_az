namespace ASP_16._Validation._Fluent_Validation.Providers;

/// <summary>
/// 
/// </summary>
public class UserInfo
{
    /// <summary>
    /// 
    /// </summary>
    public string Id { get;}

    /// <summary>
    /// 
    /// </summary>
    public string UserName { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="userName"></param>
    public UserInfo(string id, string userName)
    {
        Id = id;
        UserName = userName;
    }
}
