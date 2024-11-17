using EnglishNote.Domain.Users;
using EnglishNote.Domain.Words;

namespace EnglishNote.Domain.VocabularySets;
public class VocabularySet
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public Guid UserId { get; private set; }
    public ApplicationUser User { get; private set; }

    public string? ThumbnailId { get; private set; }

    private readonly List<Word> _words = [];
    public IReadOnlyCollection<Word> Words => _words.AsReadOnly();
}