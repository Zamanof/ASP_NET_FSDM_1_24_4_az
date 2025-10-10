using ASP_22._Background_Workers.DTOs;
using ASP_22._Background_Workers.DTOs.Pagination;
namespace ASP_22._Background_Workers.Services;

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
