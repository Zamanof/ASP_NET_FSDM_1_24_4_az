using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_11._Identity._Refresh_token.DTOs;
public class ToDoQueryFilters
{
    [FromQuery(Name = "search")]
    public string? Search { get; set; }
    [FromQuery(Name = "completed")]
    public bool? IsCompleted { get; set; }
}
