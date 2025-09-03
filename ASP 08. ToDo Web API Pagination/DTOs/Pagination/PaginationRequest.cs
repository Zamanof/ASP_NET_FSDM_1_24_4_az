using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ASP_08._ToDo_Web_API_Pagination.DTOs.Pagination;

public class PaginationRequest
{
    [Required]
    [FromQuery(Name = "page")]
    [Range(1, int.MaxValue)]
    public int Page { get; set; } = 1;
    [Required]
    [FromQuery(Name = "pageSize")]
    [Range(1, int.MaxValue)]
    public int PageSize { get; set; } = 10;

}
