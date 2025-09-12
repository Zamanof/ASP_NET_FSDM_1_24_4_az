using ASP_NET_12._Refactroing._Autorization.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_12._Refactroing._Autorization.Data;

public class ToDoContext : IdentityDbContext
{
    public ToDoContext(DbContextOptions<ToDoContext> options) 
        : base(options)
    {}

    public DbSet<ToDoItem> ToDoItems 
                                => Set<ToDoItem>();

    public DbSet<AppUser> AppUsers 
        => Set<AppUser>();
}
