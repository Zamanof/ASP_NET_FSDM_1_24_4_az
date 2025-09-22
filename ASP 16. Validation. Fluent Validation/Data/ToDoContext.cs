using ASP_16._Validation._Fluent_Validation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_16._Validation._Fluent_Validation.Data;

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
