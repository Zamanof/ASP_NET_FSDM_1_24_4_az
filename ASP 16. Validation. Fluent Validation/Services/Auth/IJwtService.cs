using System.Security.Claims;

namespace ASP_16._Validation._Fluent_Validation.Services.Auth;

public interface IJwtService
{
    string GenerateSecurityToken(
        string id,
        string email,
        IEnumerable<string> roles,
        IEnumerable<Claim> userClaims
        );
}
