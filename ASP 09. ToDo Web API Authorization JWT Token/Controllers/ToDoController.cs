using ASP_09._ToDo_Web_API_Authorization_JWT_Token.DTOs;
using ASP_09._ToDo_Web_API_Authorization_JWT_Token.DTOs.Pagination;
using ASP_09._ToDo_Web_API_Authorization_JWT_Token.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_09._ToDo_Web_API_Authorization_JWT_Token.Controllers;
/// <summary>
/// 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ToDoController : ControllerBase
{

    private readonly IToDoService _service;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="service"></param>
    public ToDoController(IToDoService service)
    {
        _service = service;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="queryFilters"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<PaginationListDTO<ToDoItemDTO>>> Get(
        [FromQuery] PaginationRequest request,
        [FromQuery] ToDoQueryFilters queryFilters
        )
    {
        return await _service.GetToDoItemsAsync(
            request.Page, 
            request.PageSize,
            queryFilters.Search,
            queryFilters.IsCompleted);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoItemDTO>> Get(int id)
    {
        var item = await _service.GetToDoItemAsync(id);
        return item is not null ? item : NotFound();
    }
    /// <summary>
    /// Create ToDo Item
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <response code="201">Success</response>
    /// <response code="409">Task already created</response>
    /// <response code="403">Forbiden</response>
    [HttpPost]
    public async Task<ActionResult<ToDoItemDTO>> Post([FromBody] CreateToDoItemRequest request)
    {
        return await _service.CreateToDoAsync(request);
    }
    /// <summary>
    /// Change ToDo item
    /// </summary>
    /// <param name="id"></param>
    /// <param name="isCompleted"></param>
    /// <returns>ToDo item with changed status</returns>
    [HttpPatch("{id}/status")]
    public async Task<ActionResult<ToDoItemDTO>> Patch(int id, [FromBody] bool isCompleted)
    {
        var todoItem = await _service.ChangeToDoItemStatusAsync(id, isCompleted);

        return todoItem is not null ? todoItem : NotFound();
    }
}

/*
 MVC:
    Create:
        GET         /products/create        -> html
        POST        /products/create        -> html
    
    Update:
        GET         /products/update/{id}   -> html
        POST        /products/update/{id}   -> html

    Delete:
        GET         /products/delete/{id}   -> html
        POST        /products/delete/{id}   -> html

    GetAll:
        GET         /products/index         -> html

    GetOne:
        GET         /products/index/{id}    -> html


API:
    Create:
        POST        /products               -> json
    
    Update:
        PUT        /products/{id}           -> json

    Delete:
        DELETE      /products/{id}          -> json

    GetAll:
        GET         /products               -> json

    GetOne:
        GET         /products/{id}          -> json



 */