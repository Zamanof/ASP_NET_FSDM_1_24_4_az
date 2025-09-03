using Microsoft.AspNetCore.Mvc;

namespace ASP_08._ToDo_Web_API_Pagination.DTOs;
public class ToDoQueryFilters
{
    [FromQuery(Name = "search")]
    public string? Search { get; set; }
    [FromQuery(Name = "completed")]
    public bool? IsCompleted { get; set; }
}
