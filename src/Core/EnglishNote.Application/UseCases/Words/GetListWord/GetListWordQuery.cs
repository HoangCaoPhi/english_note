using EnglishNote.Application.Abtractions.Queries;

namespace EnglishNote.Application.UseCases.Words.GetListWord;
public class GetListWordQuery : PagingModel, 
    IQuery<PaginatedList<GetListWordViewModel>>
{
    public string? WordText { get; set; }

    public Guid? TagId { get; set; }
}
