using EnglishNote.Application.Abtractions.Data;
using EnglishNote.Application.Abtractions.Queries;
using Shared;

namespace EnglishNote.Application.UseCases.Tags.GetListTag;
internal class GetListTagQueryHandler(IApplicationReadDbContext dbContext) : IQueryHandler<GetListTagQuery, PaginatedList<GetListTagViewModel>>
{
    public async Task<Result<PaginatedList<GetListTagViewModel>>> Handle(GetListTagQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetListTagSpecification(dbContext.GetTags(), request);
        return await spec.ApplyPaging();
    }
}
