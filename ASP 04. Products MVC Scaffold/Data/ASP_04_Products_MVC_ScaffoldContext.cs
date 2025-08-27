using Microsoft.EntityFrameworkCore;
using ASP_04._Products_MVC_Scaffold.Models;

namespace ASP_04._Products_MVC_Scaffold.Data
{
    public class ASP_04_Products_MVC_ScaffoldContext : DbContext
    {
        public ASP_04_Products_MVC_ScaffoldContext (DbContextOptions<ASP_04_Products_MVC_ScaffoldContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product => Set<Product>();
    }
}
