using EnglishNote.Domain.SeedWork;

namespace EnglishNote.Domain.AggregatesModel.Words;

public class Meaning : ValueObject
{
    public string PartOfSpeech { get; private set; }

    public string CefrLevel { get; private set; }

    public IReadOnlyList<Definition> Definitions => _definition.AsReadOnly();

    private readonly List<Definition> _definition = [];

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PartOfSpeech;
        yield return CefrLevel;
        yield return Definitions;
    }
}