using BuildingBlocks.Domain;

namespace EnglishNote.Domain.Words;
public class Synonym : ValueObject
{
    public string Value { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
