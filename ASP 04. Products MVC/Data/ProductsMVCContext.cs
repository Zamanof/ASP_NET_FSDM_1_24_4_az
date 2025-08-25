using ASP_04._Products_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_04._Products_MVC.Data;

public class ProductsMVCContext:DbContext
{
    public ProductsMVCContext(DbContextOptions options) 
        : base(options)
    {}


    public DbSet<Product> Products 
        => Set<Product>();
}
