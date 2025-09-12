using ASP_NET_11._Identity._Refresh_token.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_11._Identity._Refresh_token.Data;

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
