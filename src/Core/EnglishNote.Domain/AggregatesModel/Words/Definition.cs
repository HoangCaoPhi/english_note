using EnglishNote.Domain.SeedWork;

namespace EnglishNote.Domain.AggregatesModel.Words;
public class Definition : ValueObject
{
    public string DefinitionText { get; private set; }
    public IReadOnlyCollection<Synonym> Synonyms => _synonyms.AsReadOnly();
    public IReadOnlyCollection<Antonym> Antonyms => _antonyms.AsReadOnly();
    public IReadOnlyCollection<Example> Examples => _examples.AsReadOnly();

    public readonly List<Synonym> _synonyms = [];
    public readonly List<Antonym> _antonyms = [];
    public readonly List<Example> _examples = [];

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return DefinitionText;
        yield return Synonyms;
        yield return Antonyms;
        yield return Examples;
    }
}
