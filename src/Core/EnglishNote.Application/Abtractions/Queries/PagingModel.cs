namespace EnglishNote.Application.Abtractions.Queries;
public class PagingModel
{
    private int _pageIndex;
    private int _pageSize;

    public int? PageIndex
    {
        get => _pageIndex;
        set => _pageIndex = value ?? 1;  
    }

    public int? PageSize
    {
        get => _pageSize;
        set => _pageSize = value ?? 10; 
    }

    public string? SortField { get; set; }

    public OrderByDirectionEnum? SortDirection { get; set; }
}



public enum OrderByDirectionEnum
{
    ASC,
    DESC
}