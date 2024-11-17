using EnglishNote.Domain.Tags;
using EnglishNote.Domain.Users;
using EnglishNote.Domain.VocabularySets;

namespace EnglishNote.Domain.Words;
public class Word
{
    public Guid Id { get; private set; }  
    public string WordText { get; private set; }  
    public string? Phonetic { get; private set; }  
    public string Meaning { get; private set; } 
    public string? Example { get; private set; }  
    public MemoryLevel MemoryLevel { get; set; }  
    public string? IllustrationId { get; private set; }
    public Guid UserId { get; private set; }
    public ApplicationUser User { get; private set; }

    private readonly List<Tag> _tags = [];
    public IReadOnlyCollection<Tag> Tags => _tags.AsReadOnly();

    private readonly List<VocabularySet> _vocabularySets = [];
    public IReadOnlyCollection<VocabularySet> VocabularySets => _vocabularySets.AsReadOnly();
}