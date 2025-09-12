namespace ASP_NET_12._Refactroing._Autorization.DTOs;

public class ToDoItemDTO
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
