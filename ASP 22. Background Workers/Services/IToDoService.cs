using ASP_22._Background_Workers.DTOs;
using ASP_22._Background_Workers.DTOs.Pagination;


namespace ASP_22._Background_Workers.Services;

public interface IToDoService
{
    Task<PaginationListDto<ToDoItemDto>> GetToDoItemsAsync(
        string userId,
        int page,
        int pageSize,
        string? search,
        bool? isCompleted);
    Task<ToDoItemDto> GetToDoItemAsync(
        string userId,
        int id);
    Task<ToDoItemDto> CreateToDoAsync(
        string userId,
        CreateToDoItemRequest request);
    Task<ToDoItemDto> ChangeToDoItemStatusAsync(
        string userId, 
        int id, 
        bool isCompleted);
}

