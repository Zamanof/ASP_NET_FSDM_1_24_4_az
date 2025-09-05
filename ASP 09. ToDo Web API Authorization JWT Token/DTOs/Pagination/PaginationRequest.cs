using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ASP_09._ToDo_Web_API_Authorization_JWT_Token.DTOs.Pagination;
/// <summary>
/// Pagination request
/// </summary>
public class PaginationRequest
{
    /// <summary>
    /// Page Number
    /// </summary>
    /// <example>1</example>
    [Required]
    [FromQuery(Name = "page")]
    [Range(1, int.MaxValue)]
    public int Page { get; set; } = 1;
    
    /// <summary>
    /// Page size - Property for count of items per one page
    /// </summary>
    /// <example>10</example>
    
    [Required]
    [FromQuery(Name = "pageSize")]
    [Range(1, int.MaxValue)]
    public int PageSize { get; set; } = 10;

}
