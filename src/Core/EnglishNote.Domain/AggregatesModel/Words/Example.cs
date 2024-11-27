using EnglishNote.Domain.SeedWork;

namespace EnglishNote.Domain.AggregatesModel.Words;
public class Example : ValueObject
{
    private Example() { }

    public string Value { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    internal static Example Create(string value)
    {
        return new Example()
        {
            Value = value
        };
    }
}
