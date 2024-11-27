using EnglishNote.Domain.SeedWork;

namespace EnglishNote.Domain.AggregatesModel.Words;
public class WordPhonetic : ValueObject
{
    private WordPhonetic() { }

    public string Text { get; private set; }
    public string? Audio { get; private set; }
    public string? CustomAudio { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Text;
        yield return Audio;
        yield return CustomAudio;
    }

    internal static WordPhonetic Create(string text, 
                                        string? audio, 
                                        string? customAudio)
    {
        return new WordPhonetic() { 
            Text = text, 
            Audio = audio, 
            CustomAudio = customAudio 
        };
    }
}