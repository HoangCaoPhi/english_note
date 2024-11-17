using EnglishNote.Domain.Users;
using EnglishNote.Domain.Words;

namespace EnglishNote.Domain.Tags;
public class Tag
{
    public Guid Id { get; private set; }  
    public string Name { get; private set; }

    private readonly List<Word> _words = [];
    public IReadOnlyCollection<Word> Words => _words.AsReadOnly();

    public Guid UserId { get; private set; }
    public ApplicationUser User { get; private set; }
}