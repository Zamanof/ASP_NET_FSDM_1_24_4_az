using ASP_NET_12._Refactroing._Autorization.DTOs;
using ASP_NET_12._Refactroing._Autorization.DTOs.Pagination;
namespace ASP_NET_12._Refactroing._Autorization.Services;

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
