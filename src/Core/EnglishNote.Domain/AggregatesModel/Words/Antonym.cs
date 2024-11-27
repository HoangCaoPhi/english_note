using EnglishNote.Domain.SeedWork;

namespace EnglishNote.Domain.AggregatesModel.Words;
public class Antonym : ValueObject
{
    private Antonym() { }

    public string? Value { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    internal static Antonym Create(string value)
    {
        return new Antonym()
        {
            Value = value
        };
    }
}
