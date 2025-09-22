using ASP_16._Validation._Fluent_Validation.DTOs;
using ASP_16._Validation._Fluent_Validation.DTOs.Pagination;
namespace ASP_16._Validation._Fluent_Validation.Services;

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
