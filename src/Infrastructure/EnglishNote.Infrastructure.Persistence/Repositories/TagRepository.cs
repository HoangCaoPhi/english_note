using EnglishNote.Domain.Tags;
using EnglishNote.Infrastructure.Persistence.Contexts;

namespace EnglishNote.Infrastructure.Persistence.Repositories;
internal sealed class TagRepository(ApplicationWriteDbContext applicationWriteDbContext) : ITagRepository
{
    public void Add(Tag tag)
        => applicationWriteDbContext
                .Tags
                .Add(tag);
}
