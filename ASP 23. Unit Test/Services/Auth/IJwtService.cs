using System.Security.Claims;

namespace ASP_23._Unit_Test.Services.Auth;

public interface IJwtService
{
    string GenerateSecurityToken(
        string Id,
        string email,
        IEnumerable<string> roles,
        IEnumerable<Claim> userClaims
        );
}
