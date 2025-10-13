using Microsoft.AspNetCore.Identity;

namespace ASP_23._Unit_Test.Models;
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
