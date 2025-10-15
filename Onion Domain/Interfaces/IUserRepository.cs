using Onion_Domain.Entities;

namespace Onion_Domain.Interfaces;

public interface IUserRepository
{
    User GetUserById(int id);
    IEnumerable<User> GetAllUsers();
    void AddUser(User user);
    void Save();
}
