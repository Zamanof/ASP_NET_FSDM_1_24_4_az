using ASP_NET_12._Refactroing._Autorization.DTOs;
using ASP_NET_12._Refactroing._Autorization.DTOs.Pagination;
namespace ASP_NET_12._Refactroing._Autorization.Services;

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
