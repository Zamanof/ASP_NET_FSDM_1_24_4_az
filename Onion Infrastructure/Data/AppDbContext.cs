using Microsoft.EntityFrameworkCore;
using Onion_Domain.Entities;

namespace Onion_Infrastructure.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<User> Users { get; set; }
}
