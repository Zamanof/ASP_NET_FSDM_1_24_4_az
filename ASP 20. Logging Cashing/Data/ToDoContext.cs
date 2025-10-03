using ASP_20._Logging_Cashing.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_20._Logging_Cashing.Data;

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
