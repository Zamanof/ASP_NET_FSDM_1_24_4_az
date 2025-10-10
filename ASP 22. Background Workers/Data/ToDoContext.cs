using ASP_22._Background_Workers.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_22._Background_Workers.Data;

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
