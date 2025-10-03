using Microsoft.AspNetCore.Mvc;

namespace ASP_20._Logging_Cashing.DTOs;
public class ToDoQueryFilters
{
    [FromQuery(Name = "search")]
    public string? Search { get; set; }
    [FromQuery(Name = "completed")]
    public bool? IsCompleted { get; set; }
}
