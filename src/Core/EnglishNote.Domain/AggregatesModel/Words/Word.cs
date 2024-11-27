using EnglishNote.Domain.AggregatesModel.Identity;
using EnglishNote.Domain.AggregatesModel.Tags;
using EnglishNote.Domain.AggregatesModel.VocabularySets;
using EnglishNote.Domain.SeedWork;

namespace EnglishNote.Domain.AggregatesModel.Words;

public class Word : AggregateRoot
{
    public string WordText { get; private set; }
    public IReadOnlyList<WordPhonetic> Phonetics => _phonetics.AsReadOnly();
    public IReadOnlyList<WordMeaning> Meanings => _meanings.AsReadOnly();
    public MemoryLevel? MemoryLevel { get; private set; }

    public Tag? Tag { get; private set; }
    public Guid? TagId { get; private set; }

    public Guid UserId { get; private set; }
    public ApplicationUser User { get; private set; }

    public VocabularySet? VocabularySet { get; private set; }
    public Guid? VocabularySetId { get; private set; }

    private readonly List<WordPhonetic> _phonetics = [];
    private readonly List<WordMeaning> _meanings = [];

    public static Word Create(Guid id,
                              string wordText,
                              Guid? tagId,
                              Guid? vocabularySetId,
                              Guid userId,
                              MemoryLevel? memoryLevel

    )
    {
        var word = new Word()
        {
           Id = id,
           WordText = wordText,
           TagId = tagId,
           VocabularySetId = vocabularySetId,
           UserId = userId,
           MemoryLevel = memoryLevel
        }; 

        return word;
    }

    public void AddPhonetic(string text, 
        string? audio, 
        string? customAudio)
    {
        var phonetic = WordPhonetic.Create(text, audio, customAudio);
        _phonetics.Add(phonetic);
    }

    public void AddMeaning(PartOfSpeech? partOfSpeech, CefrLevel? cefrLevel)
    {
        var meaning = WordMeaning.Create(partOfSpeech, cefrLevel);
        _meanings.Add(meaning);
    }

    public WordMeaning CreateAndAddMeaning(PartOfSpeech? partOfSpeech, CefrLevel? cefrLevel)
    {
        var meaning = WordMeaning.Create(partOfSpeech, cefrLevel);
        _meanings.Add(meaning);
        return meaning;
    }

    public void AddDefinition(WordMeaning meaning,
         string definitionText,
         List<string> synonyms,
         List<string> antonyms,
         List<string> examples)
    { 
         meaning.AddDefinition(definitionText, synonyms, antonyms, examples);
    }
}
