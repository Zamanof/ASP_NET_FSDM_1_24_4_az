using ASP_NET_11._Identity._Refresh_token.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_11._Identity._Refresh_token.Data;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions options) 
        : base(options)
    {}

    public DbSet<ToDoItem> ToDoItems 
                                => Set<ToDoItem>();

}
