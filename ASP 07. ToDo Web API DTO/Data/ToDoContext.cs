using ASP_07._ToDo_Web_API_DTO.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_07._ToDo_Web_API_DTO.Data;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions options) 
        : base(options)
    {}

    public DbSet<ToDoItem> ToDoItems 
                                => Set<ToDoItem>();

}
