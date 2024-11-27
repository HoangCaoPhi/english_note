using EnglishNote.Domain.SeedWork;

namespace EnglishNote.Domain.AggregatesModel.Words;

public class WordMeaning : ValueObject
{
    private WordMeaning() { }

    public PartOfSpeech? PartOfSpeech { get; private set; }

    public CefrLevel? CefrLevel { get; private set; }

    public IReadOnlyList<Definition> Definitions => _definitions.AsReadOnly();

    private readonly List<Definition> _definitions = [];

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PartOfSpeech;
        yield return CefrLevel;
        yield return Definitions;
    }

    internal static WordMeaning Create(PartOfSpeech? partOfSpeech, CefrLevel? cefrLevel)
    {
        var meaning = new WordMeaning
        {
            PartOfSpeech = partOfSpeech,
            CefrLevel = cefrLevel,
        }; 
        return meaning;
    }

    internal void AddDefinition(string definitionText,
         List<string> synonyms,
         List<string> antonyms,
         List<string> examples)
    {
         var definition = Definition.Create(definitionText, synonyms, antonyms, examples);
        _definitions.Add(definition);
    }  
}