using EnglishNote.Application.Abtractions.Data;
using EnglishNote.Application.Abtractions.Queries;
using Shared;

namespace EnglishNote.Application.UseCases.Words.GetListWord;
internal sealed class GetListWordQueryHandler(IApplicationReadDbContext dbContext) : IQueryHandler<GetListWordQuery, PaginatedList<GetListWordViewModel>>
{
    public async Task<Result<PaginatedList<GetListWordViewModel>>> Handle(GetListWordQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetListWordSpecification(dbContext.GetWords(), request);
        return await spec.ApplyPaging();
    }
}
