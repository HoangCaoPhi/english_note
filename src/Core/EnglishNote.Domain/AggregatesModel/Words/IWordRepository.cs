namespace EnglishNote.Domain.AggregatesModel.Words;
public interface IWordRepository
{
    Task AddAsync(Word word, CancellationToken cancellationToken = default);
}
