using ASP_08._ToDo_Web_API_Pagination.DTOs;
using ASP_08._ToDo_Web_API_Pagination.DTOs.Pagination;
namespace ASP_08._ToDo_Web_API_Pagination.Services;

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
