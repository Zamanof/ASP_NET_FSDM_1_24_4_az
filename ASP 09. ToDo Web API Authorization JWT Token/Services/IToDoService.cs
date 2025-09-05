using ASP_09._ToDo_Web_API_Authorization_JWT_Token.DTOs;
using ASP_09._ToDo_Web_API_Authorization_JWT_Token.DTOs.Pagination;
namespace ASP_09._ToDo_Web_API_Authorization_JWT_Token.Services;

public interface IToDoService
{
    Task<PaginationListDTO<ToDoItemDTO>> GetToDoItemsAsync(
        int page, 
        int pageSize,
        string? search,
        bool? isCompleted);
    Task<ToDoItemDTO> GetToDoItemAsync(int id);
    Task<ToDoItemDTO> CreateToDoAsync(CreateToDoItemRequest request);
    Task<ToDoItemDTO> ChangeToDoItemStatusAsync(int id, bool isCompleted);
}
