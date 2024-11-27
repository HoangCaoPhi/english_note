using EnglishNote.Domain.SeedWork;

namespace EnglishNote.Domain.AggregatesModel.Words;
public class Synonym : ValueObject
{
    private Synonym() { }

    public string Value { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    internal static Synonym Create(string value)
    {
        return new Synonym() { Value = value };
    }
}
