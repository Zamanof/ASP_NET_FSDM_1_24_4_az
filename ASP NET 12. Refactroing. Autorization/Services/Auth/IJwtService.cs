using System.Security.Claims;

namespace ASP_NET_12._Refactroing._Autorization.Services.Auth;

public interface IJwtService
{
    string GenerateSecurityToken(
        string id,
        string email,
        IEnumerable<string> roles,
        IEnumerable<Claim> userClaims
        );
}
