using EnglishNote.Application.Abtractions.Data;
using EnglishNote.Application.Abtractions.Queries;
using EnglishNote.Domain.AggregatesModel.Tags;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace EnglishNote.Application.UseCases.Tags.GetOneTag;
internal class GetOneTagQueryHandler(IApplicationReadDbContext context) :
    IQueryHandler<GetOneTagQuery, GetOneTagViewModel>
{
    public async Task<Result<GetOneTagViewModel>> Handle(GetOneTagQuery request, CancellationToken cancellationToken)
    {
        var data = await context
                    .GetTags()
                    .Where(x => x.Id == request.TagId)
                    .ProjectToType<GetOneTagViewModel>()
                    .FirstOrDefaultAsync(cancellationToken);

        if (data is null)
            return Result<GetOneTagViewModel>.Failure(TagErrors.NotFound);

        return data;
    }
}
