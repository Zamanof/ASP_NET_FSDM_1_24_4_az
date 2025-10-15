using Onion_Application.DTOs;
using Onion_Domain.Entities;
using Onion_Domain.Servises;
namespace Onion_Application.Services;
public class UserAppService
{
    private readonly UserService _userService;
    public UserAppService(UserService userService)
    {
        _userService = userService;
    }
    public void CreateUser(UserDto userDto)
    {
        _userService.CreateUser(userDto.FirstName, userDto.LastName, userDto.Email);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userService.GetAllUsers();
    }
    public User GetUserById(int id)
    {
        return _userService.GetUserById(id);
    }

}
