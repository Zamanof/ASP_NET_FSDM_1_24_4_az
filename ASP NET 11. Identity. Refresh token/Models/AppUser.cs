using Microsoft.AspNetCore.Identity;

namespace ASP_NET_11._Identity._Refresh_token.Models;
/// <summary>
/// 
/// </summary>
public class AppUser : IdentityUser
{ 
    /// <summary>
    /// 
    /// </summary>
    public string? RefreshToken { get; set; }
}
