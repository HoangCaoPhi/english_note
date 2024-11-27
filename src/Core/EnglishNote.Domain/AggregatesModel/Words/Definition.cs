using EnglishNote.Domain.SeedWork;

namespace EnglishNote.Domain.AggregatesModel.Words;
public class Definition : ValueObject
{
    private Definition() { }

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

    internal static Definition Create(string definitionText,
                                      List<string> synonyms,
                                      List<string> antonyms,
                                      List<string> examples)
    {
        var definition = new Definition()
        {
            DefinitionText = definitionText
        };

        definition.AddExample(examples);
        definition.AddSynonyms(synonyms);
        definition.AddAntonyms(antonyms);

        return definition;
    }

    internal void AddSynonyms(List<string> synonyms) {
        foreach (var item in synonyms)
        {
            _synonyms.Add(Synonym.Create(item));
        }
    }

    internal void AddAntonyms(List<string> antonyms)
    {
        foreach (var item in antonyms)
        {
            _antonyms.Add(Antonym.Create(item));
        }
    }

    internal void AddExample(List<string> examples)
    {
        foreach(var item in examples)
        {
            _examples.Add(Example.Create(item));
        }
    }
}
