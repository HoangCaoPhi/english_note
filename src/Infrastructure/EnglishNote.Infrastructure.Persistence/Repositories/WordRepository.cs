using EnglishNote.Domain.AggregatesModel.Words;
using EnglishNote.Infrastructure.Persistence.Contexts;

namespace EnglishNote.Infrastructure.Persistence.Repositories;
internal sealed class WordRepository(ApplicationWriteDbContext context) : IWordRepository
{
    public async Task AddAsync(Word word, CancellationToken cancellationToken = default)
     => await context.AddAsync(word, cancellationToken);
}
