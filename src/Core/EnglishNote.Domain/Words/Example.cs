using BuildingBlocks.Domain;

namespace EnglishNote.Domain.Words;
public class Example : ValueObject
{
    public string Value { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
