using Microsoft.AspNetCore.Mvc;

namespace ASP_09._ToDo_Web_API_Authorization_JWT_Token.DTOs;
public class ToDoQueryFilters
{
    [FromQuery(Name = "search")]
    public string? Search { get; set; }
    [FromQuery(Name = "completed")]
    public bool? IsCompleted { get; set; }
}
