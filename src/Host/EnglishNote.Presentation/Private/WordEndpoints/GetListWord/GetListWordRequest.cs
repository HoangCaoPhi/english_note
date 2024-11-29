using EnglishNote.Application.Abtractions.Queries;
using EnglishNote.Application.UseCases.Words.GetListWord;

namespace EnglishNote.Presentation.Private.WordEndpoints.GetListWord;

public class GetListWordRequest : PagingModel,
    IQuery<PaginatedList<GetListWordViewModel>>
{
    public string? WordText { get; set; }

    public Guid? TagId { get; set; }
}
