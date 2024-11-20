namespace EnglishNote.Domain.Words;

public class Word
{
    public string WordText { get; private set; }
    public IReadOnlyList<Phonetic> Phonetics { get; private set; }
    public IReadOnlyList<Meaning> Meanings { get; private set; } 
    public IReadOnlyList<string> SourceUrls { get; private set; }

    private readonly List<Phonetic> _phonetics = [];
    private readonly List<Meaning> _meanings = [];
    private readonly List<string> _sourceUrls = [];
}