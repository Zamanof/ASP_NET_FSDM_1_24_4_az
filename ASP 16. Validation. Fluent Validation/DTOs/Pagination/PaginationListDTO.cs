namespace ASP_16._Validation._Fluent_Validation.DTOs.Pagination;
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
