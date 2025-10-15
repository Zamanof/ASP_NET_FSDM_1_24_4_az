using Onion_Domain.Entities;
using Onion_Domain.Interfaces;
using Onion_Infrastructure.Data;

namespace Onion_Infrastructure.Repositories;
public class UserRepository: IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _context.Users.ToList() ;
    }

    public User GetUserById(int id)
    {
        return _context.Users.Find(id)!;
    }

    public void Save()
    {
       _context.SaveChanges();
    }
}
