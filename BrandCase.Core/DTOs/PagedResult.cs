namespace BrandCase.Core.DTOs;

public class PagedResult<T>
{
    public int TotalCount { get; set; }
    public List<T> Rows { get; set; } = new();
}
