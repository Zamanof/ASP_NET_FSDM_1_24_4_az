using ASP_NET_12._Refactroing._Autorization.Data;
using ASP_NET_12._Refactroing._Autorization.DTOs;
using ASP_NET_12._Refactroing._Autorization.DTOs.Pagination;
using ASP_NET_12._Refactroing._Autorization.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_12._Refactroing._Autorization.Services;

public class ToDoService : IToDoService
{
    private readonly ToDoContext _context;

    public ToDoService(ToDoContext context)
    {
        _context = context;
    }

    public Task<ToDoItemDTO> ChangeToDoItemStatusAsync(string userId, int id, bool isCompleted)
    {
        var item = _context.ToDoItems.FirstOrDefault(t => t.Id == id && t.UserId == userId);

        if (item is null) return null!;

        item.IsCompleted = isCompleted;
        item.UpdatedAt = DateTimeOffset.UtcNow;

        _context.SaveChanges();

        return Task.FromResult(ConvertToDoItemDTO(item));

    }

    public async Task<ToDoItemDTO> CreateToDoAsync(string userId, CreateToDoItemRequest request)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user is null) throw new KeyNotFoundException();

        var now = DateTime.UtcNow;

        var item = new ToDoItem()
        {
            Text = request.Text,
            CreatedAt = now,
            UpdatedAt = now,
            IsCompleted = false,
            UserId = userId
        };
        item = _context.ToDoItems.Add(item).Entity;
        await _context.SaveChangesAsync();
        
        return ConvertToDoItemDTO(item);
    }

    public async Task<ToDoItemDTO> GetToDoItemAsync(string userId, int id)
    {
        var item = _context.ToDoItems.FirstOrDefault(t => t.Id == id && t.UserId == userId);
        
        return item is not null ? ConvertToDoItemDTO(item!): null!;
    }

    public async Task<PaginationListDTO<ToDoItemDTO>> GetToDoItemsAsync(
        string userId,
        int page,
        int pageSize,
        string? search,
        bool? isCompleted)
    {
        IQueryable<ToDoItem> query = _context.ToDoItems.Where(t=> t.UserId == userId);

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(item => item.Text.ToLower().Contains(search));
        }

        if (isCompleted.HasValue)
        {
            query = query.Where(item => item.IsCompleted == isCompleted);
        }
        var items = await query
            .Skip((page-1)*pageSize)
            .Take(pageSize)
            .ToListAsync();

        
        return new PaginationListDTO<ToDoItemDTO>(
            items.Select(item=> ConvertToDoItemDTO(item)),
            new PaginationMeta(page, pageSize, query.Count())
            );
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
