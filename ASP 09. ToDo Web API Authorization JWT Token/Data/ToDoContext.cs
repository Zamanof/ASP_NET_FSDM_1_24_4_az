using ASP_09._ToDo_Web_API_Authorization_JWT_Token.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_09._ToDo_Web_API_Authorization_JWT_Token.Data;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions options) 
        : base(options)
    {}

    public DbSet<ToDoItem> ToDoItems 
                                => Set<ToDoItem>();

}
