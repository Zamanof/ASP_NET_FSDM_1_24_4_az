using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_12._Refactroing._Autorization.DTOs;
public class ToDoQueryFilters
{
    [FromQuery(Name = "search")]
    public string? Search { get; set; }
    [FromQuery(Name = "completed")]
    public bool? IsCompleted { get; set; }
}
