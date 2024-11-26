using EnglishNote.Application.Abtractions.Queries;

namespace EnglishNote.Application.UseCases.Tags.GetListTag;
public class GetListTagQuery : PagingModel, IQuery<PaginatedList<GetListTagViewModel>>
{
    public string? Name { get; set; }

    public string? Description { get; set; }
}
