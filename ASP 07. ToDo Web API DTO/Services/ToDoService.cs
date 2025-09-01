using ASP_07._ToDo_Web_API_DTO.Data;
using ASP_07._ToDo_Web_API_DTO.DTOs;
using ASP_07._ToDo_Web_API_DTO.Models;

namespace ASP_07._ToDo_Web_API_DTO.Services;

public class ToDoService : IToDoService
{
    private readonly ToDoContext _context;

    public ToDoService(ToDoContext context)
    {
        _context = context;
    }

    public Task<ToDoItemDTO> ChangeToDoItemStatusAsync(int id, bool isCompleted)
    {
        throw new NotImplementedException();
    }

    public Task<ToDoItemDTO> CreateToDoAsync(CreateToDoItemRequest request)
    {
        var item = new ToDoItem()
        {
            Text = request.Text,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsCompleted = false
        };
        _context.ToDoItems.Add(item);
        _context.SaveChanges();
        
        return Task.FromResult(ConvertToDoItemDTO(item));
    }

    public Task<ToDoItemDTO> GetToDoItemAsync(int id)
    {
        var item = _context.ToDoItems.FirstOrDefault(t => t.Id == id);
        
        return Task.FromResult(ConvertToDoItemDTO(item!));
    }

    public Task<IEnumerable<ToDoItemDTO>> GetToDoItemsAsync()
    {
        var items = _context.ToDoItems.ToList();        
        return Task.FromResult(items.Select(ConvertToDoItemDTO));
    }

    private ToDoItemDTO ConvertToDoItemDTO(ToDoItem item)
    {
        ToDoItemDTO todoItem = new()
        {
            Id = item.Id,
            Text = item.Text,
            CreatedAt = item.CreatedAt,
            IsCompleted = item.IsCompleted
        };
        return todoItem;
    }
}
