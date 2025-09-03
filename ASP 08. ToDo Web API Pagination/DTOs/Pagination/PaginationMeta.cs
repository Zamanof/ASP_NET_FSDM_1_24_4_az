namespace ASP_08._ToDo_Web_API_Pagination.DTOs.Pagination;

public class PaginationMeta
{
    public int Page { get; }
    public int PageSize { get; }
    public int TotalPages { get; }

    public PaginationMeta(int page, int pageSize, int totalCount)
    {
        Page = page;
        PageSize = pageSize;
        TotalPages = Convert.ToInt32(Math.Ceiling(1.0f * totalCount / pageSize));
    }
}
