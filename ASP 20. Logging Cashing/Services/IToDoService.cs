using ASP_20._Logging_Cashing.DTOs;
using ASP_20._Logging_Cashing.DTOs.Pagination;
namespace ASP_20._Logging_Cashing.Services;

public interface IToDoService
{
    Task<PaginationListDTO<ToDoItemDTO>> GetToDoItemsAsync(
        string userId,
        int page, 
        int pageSize,
        string? search,
        bool? isCompleted);
    Task<ToDoItemDTO> GetToDoItemAsync(string userId, int id);
    Task<ToDoItemDTO> CreateToDoAsync(string userId, CreateToDoItemRequest request);
    Task<ToDoItemDTO> ChangeToDoItemStatusAsync(string userId, int id, bool isCompleted);
}
