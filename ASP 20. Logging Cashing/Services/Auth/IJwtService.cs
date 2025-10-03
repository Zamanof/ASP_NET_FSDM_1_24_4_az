using System.Security.Claims;

namespace ASP_20._Logging_Cashing.Services.Auth;

public interface IJwtService
{
    string GenerateSecurityToken(
        string id,
        string email,
        IEnumerable<string> roles,
        IEnumerable<Claim> userClaims
        );
}
