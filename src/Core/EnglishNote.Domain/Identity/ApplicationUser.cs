using EnglishNote.Domain.Tags;
using EnglishNote.Domain.VocabularySets;
using EnglishNote.Domain.Words;
using Microsoft.AspNetCore.Identity;

namespace EnglishNote.Domain.Identity;
public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    private readonly List<VocabularySet> _vocabularySet = [];
    public IReadOnlyCollection<VocabularySet> VocabularySets => _vocabularySet.AsReadOnly();

    private readonly List<Tag> _tag = [];
    public IReadOnlyCollection<Tag> Tags => _tag.AsReadOnly();

    private readonly List<Word> _word = [];
    public IReadOnlyCollection<Word> Words => _word.AsReadOnly();
}
