namespace EnglishNote.Domain.Words;
public class Definition
{
    public string DefinitionText { get; private set; }
    public List<Synonym> Synonyms { get; private set; }
    public List<Antonym> Antonyms { get; private set; }  
    public List<Antonym> Examples { get; private set; }  

    public readonly List<Synonym> _synonyms = [];
    public readonly List<Antonym> _antonyms = [];
    public readonly List<Antonym> _examples = [];
}
