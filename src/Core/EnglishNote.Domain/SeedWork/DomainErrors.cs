namespace EnglishNote.Domain.SeedWork;
public class DomainErrors
{
    public static Error NotFound(string entityType) => Error.NotFound(entityType, $"The {entityType} was not found");
}
