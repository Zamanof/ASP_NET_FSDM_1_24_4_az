using ASP_08._ToDo_Web_API_Pagination.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_08._ToDo_Web_API_Pagination.Data;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions options) 
        : base(options)
    {}

    public DbSet<ToDoItem> ToDoItems 
                                => Set<ToDoItem>();

}
