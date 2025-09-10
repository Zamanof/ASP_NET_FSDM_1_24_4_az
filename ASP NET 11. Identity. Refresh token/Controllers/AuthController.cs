using ASP_NET_11._Identity._Refresh_token.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace ASP_NET_11._Identity._Refresh_token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<AuthTokenDTO>> Login([FromBody] LoginRequest request)
        {
            if (request is not { Login: "admin", Password: "admin" }) return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, "admin"),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, "admin"),
                //new Claim("CanTest", "true")
                new Claim("permissions", JsonSerializer.Serialize(new[]
                {
                    "CanTest",
                    "CanDelete",
                    "CanEdit",
                    "CanView",
                    "CanCreate"
                }))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ElektrikleshdirebildiklerimizdensinizmiElektrikleshdirebildiklerimizdensinizmi"));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "https://localhost:5069",
                audience: "https://localhost:5069",
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: signingCredentials,
                claims: claims);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);


            return new AuthTokenDTO { Token = tokenValue };
        }
    }
}
