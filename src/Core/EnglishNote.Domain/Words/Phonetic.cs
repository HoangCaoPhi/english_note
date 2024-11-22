using BuildingBlocks.Domain;

namespace EnglishNote.Domain.Words;
public class Phonetic : ValueObject
{
    public string Text { get; private set; }
    public string? Audio { get; private set; }
    public string? CustomAudio { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Text;
        yield return Audio;
        yield return CustomAudio;
    }
}