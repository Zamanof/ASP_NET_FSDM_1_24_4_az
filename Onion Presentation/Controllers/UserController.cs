using Microsoft.AspNetCore.Mvc;
using Onion_Application.DTOs;
using Onion_Application.Services;
using Onion_Domain.Entities;

namespace Onion_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserAppService _userAppService;
        public UserController(UserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _userAppService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userAppService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _userAppService.CreateUser(user);
            return Ok("User created successfully");
        }
    }
}
