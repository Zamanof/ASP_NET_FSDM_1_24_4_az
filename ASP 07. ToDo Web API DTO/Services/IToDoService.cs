using ASP_07._ToDo_Web_API_DTO.DTOs;
using ASP_07._ToDo_Web_API_DTO.Models;
namespace ASP_07._ToDo_Web_API_DTO.Services;

public interface IToDoService
{
    Task<IEnumerable<ToDoItemDTO>> GetToDoItemsAsync();
    Task<ToDoItemDTO> GetToDoItemAsync(int id);
    Task<ToDoItemDTO> CreateToDoAsync(CreateToDoItemRequest request);
    Task<ToDoItemDTO> ChangeToDoItemStatusAsync(int id, bool isCompleted);
}
