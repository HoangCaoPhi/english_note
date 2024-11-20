namespace EnglishNote.Domain.Words;

public class Meaning
{
    public string PartOfSpeech { get; private set; }

    public string CefrLevel { get; private set; }

    public IReadOnlyList<Definition> Definitions { get; private set; }

    private readonly List<Definition> _definition = [];
}