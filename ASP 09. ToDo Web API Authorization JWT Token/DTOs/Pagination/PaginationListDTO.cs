namespace ASP_09._ToDo_Web_API_Authorization_JWT_Token.DTOs.Pagination;
public class PaginationListDTO<T>
{
    public IEnumerable<T> Items { get; }
    public PaginationMeta Meta { get; }

    public PaginationListDTO(IEnumerable<T> items, PaginationMeta meta)
    {
        Items = items;
        Meta = meta;
    }
}
