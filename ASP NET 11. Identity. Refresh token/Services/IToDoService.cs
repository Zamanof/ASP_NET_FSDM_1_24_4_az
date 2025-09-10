using ASP_NET_11._Identity._Refresh_token.DTOs;
using ASP_NET_11._Identity._Refresh_token.DTOs.Pagination;
namespace ASP_NET_11._Identity._Refresh_token.Services;

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
