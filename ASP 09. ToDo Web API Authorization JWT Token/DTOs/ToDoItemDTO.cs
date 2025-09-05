namespace ASP_09._ToDo_Web_API_Authorization_JWT_Token.DTOs;

public class ToDoItemDTO
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
