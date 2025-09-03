using ASP_08._ToDo_Web_API_Pagination.DTOs;
using ASP_08._ToDo_Web_API_Pagination.DTOs.Pagination;
using ASP_08._ToDo_Web_API_Pagination.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_08._ToDo_Web_API_Pagination.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDoController : ControllerBase
{

    private readonly IToDoService _service;

    public ToDoController(IToDoService service)
    {
        _service = service;
    }

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

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoItemDTO>> Get(int id)
    {
        var item = await _service.GetToDoItemAsync(id);
        return item is not null ? item : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<ToDoItemDTO>> Post([FromBody] CreateToDoItemRequest request)
    {
        return await _service.CreateToDoAsync(request);
    }

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