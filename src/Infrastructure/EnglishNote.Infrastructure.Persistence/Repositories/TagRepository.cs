using EnglishNote.Domain.Tags;
using EnglishNote.Infrastructure.Persistence.Contexts;

namespace EnglishNote.Infrastructure.Persistence.Repositories;
internal sealed class TagRepository(ApplicationWriteDbContext applicationWriteDbContext) : ITagRepository
{
    public async Task AddAsync(Tag tag)
        => await applicationWriteDbContext
                .Tags
                .AddAsync(tag);
}
