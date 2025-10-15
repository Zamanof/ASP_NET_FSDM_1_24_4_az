using Microsoft.EntityFrameworkCore;
using N_tier.Models.Models;

namespace N_tier.Data.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<Product> Products { get; set; }
}
