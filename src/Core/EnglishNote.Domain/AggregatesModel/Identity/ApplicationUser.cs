using EnglishNote.Domain.AggregatesModel.Tags;
using EnglishNote.Domain.AggregatesModel.VocabularySets;
using EnglishNote.Domain.AggregatesModel.Words;
using Microsoft.AspNetCore.Identity;

namespace EnglishNote.Domain.AggregatesModel.Identity;
public class ApplicationUser : IdentityUser<Guid>
{
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }

    private readonly List<VocabularySet> _vocabularySet = [];
    public IReadOnlyCollection<VocabularySet> VocabularySets => _vocabularySet.AsReadOnly();

    private readonly List<Tag> _tag = [];
    public IReadOnlyCollection<Tag> Tags => _tag.AsReadOnly();

    private readonly List<Word> _word = [];
    public IReadOnlyCollection<Word> Words => _word.AsReadOnly();
}
