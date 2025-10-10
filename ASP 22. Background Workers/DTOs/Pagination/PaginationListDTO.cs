namespace ASP_22._Background_Workers.DTOs.Pagination;
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
