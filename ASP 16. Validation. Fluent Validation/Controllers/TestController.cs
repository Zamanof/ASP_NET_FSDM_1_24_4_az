using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_16._Validation._Fluent_Validation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "CanTest")]
    public class TestController : ControllerBase
    {
        [HttpGet("test")]
        public async Task<ActionResult> Test()
        {
            return Ok("It works");
        }
    }
}
