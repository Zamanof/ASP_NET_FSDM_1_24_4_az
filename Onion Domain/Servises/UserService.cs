using Onion_Domain.Entities;
using Onion_Domain.Interfaces;

namespace Onion_Domain.Servises;

public class UserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public User GetUserById(int id)
    {
        return _userRepository.GetUserById(id);
    }
    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }
    public void AddUser(User user)
    {
        _userRepository.AddUser(user);        
    }
    public void CreateUser(string firstName, string lastName, string email)
    {
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };
        _userRepository.AddUser(user);
        _userRepository.Save();
    }
}
