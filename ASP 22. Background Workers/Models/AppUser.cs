using Microsoft.AspNetCore.Identity;

namespace ASP_22._Background_Workers.Models;
/// <summary>
/// 
/// </summary>
public class AppUser : IdentityUser
{
    /// <summary>
    /// 
    /// </summary>
    public string? RefreshToken {  get; set; }

    public virtual ICollection<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
}
