using EnglishNote.Application.Abtractions.Data;
using EnglishNote.Application.Abtractions.Queries;
using EnglishNote.Domain.AggregatesModel.Words;
using EnglishNote.Domain.SeedWork;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace EnglishNote.Application.UseCases.Words.GetOneWord;
internal sealed class GetOneWordQueryHandler(IApplicationReadDbContext dbContext)
    : IQueryHandler<GetOneWordQuery, GetOneWordViewModel>
{
    public async Task<Result<GetOneWordViewModel>> Handle(GetOneWordQuery request, CancellationToken cancellationToken)
    {
        var result = await dbContext
                           .GetWords()
                           .Where(x => x.Id == request.Id)
                           .ProjectToType<GetOneWordViewModel>()
                           .FirstOrDefaultAsync(cancellationToken);

        if (result is null)
            return Result<GetOneWordViewModel>.Failure(DomainErrors.NotFound(typeof(Word).Name));

        return result;
    }
}
