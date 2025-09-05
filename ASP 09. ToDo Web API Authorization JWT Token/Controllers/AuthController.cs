using ASP_09._ToDo_Web_API_Authorization_JWT_Token.DTOs.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_09._ToDo_Web_API_Authorization_JWT_Token.Controllers
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
            if (request is not { Login:"admin", Password:"admin"}) return Unauthorized();
            return Ok();
        }
    }
}
