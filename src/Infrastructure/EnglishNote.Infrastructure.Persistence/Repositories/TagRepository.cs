using EnglishNote.Domain.AggregatesModel.Tags;
using EnglishNote.Infrastructure.Persistence.Contexts;

namespace EnglishNote.Infrastructure.Persistence.Repositories;
internal sealed class TagRepository(ApplicationWriteDbContext applicationWriteDbContext) : ITagRepository
{
    public async Task AddAsync(Tag tag, CancellationToken cancellationToken)
        => await applicationWriteDbContext
                .Tags
                .AddAsync(tag, cancellationToken);
}
