namespace ASP_08._ToDo_Web_API_Pagination.DTOs;

public class ToDoItemDTO
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
