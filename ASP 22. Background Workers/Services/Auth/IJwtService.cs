using System.Security.Claims;

namespace ASP_22._Background_Workers.Services.Auth;

public interface IJwtService
{
    string GenerateSecurityToken(
        string Id,
        string email,
        IEnumerable<string> roles,
        IEnumerable<Claim> userClaims
        );
}
