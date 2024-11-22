using BuildingBlocks.Domain;
using EnglishNote.Domain.Identity;
using EnglishNote.Domain.Tags;
using EnglishNote.Domain.VocabularySets;

namespace EnglishNote.Domain.Words;

public class Word : AggregateRoot
{
    public string WordText { get; private set; }
    public IReadOnlyList<Phonetic> Phonetics => _phonetics.AsReadOnly();
    public IReadOnlyList<Meaning> Meanings => _meanings.AsReadOnly();
    public MemoryLevel? MemoryLevel { get; private set; }

    public Tag Tag { get; private set; }
    public Guid TagId { get; private set; }

    public Guid UserId { get; private set; }
    public ApplicationUser User { get; private set; }

    public VocabularySet VocabularySet { get; private set; }
    public Guid VocabularySetId { get; private set; }

    private readonly List<Phonetic> _phonetics = [];
    private readonly List<Meaning> _meanings = [];
}