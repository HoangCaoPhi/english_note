namespace EnglishNote.Application.Abtractions;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
    DateTime Now { get; }
}