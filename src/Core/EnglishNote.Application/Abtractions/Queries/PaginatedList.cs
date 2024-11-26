namespace EnglishNote.Application.Abtractions.Queries;
public class PaginatedList<T>(IReadOnlyCollection<T> items, int count, int pageIndex, int pageSize)
{
    public int PageIndex { get; private set; } = pageIndex;
    public int TotalPages { get; private set; } = (int)Math.Ceiling(count / (double)pageSize);

    public bool HasPreviousPage => PageIndex > 1;

    public bool HasNextPage => PageIndex < TotalPages;

    public IReadOnlyCollection<T> Items { get; } = items;
}