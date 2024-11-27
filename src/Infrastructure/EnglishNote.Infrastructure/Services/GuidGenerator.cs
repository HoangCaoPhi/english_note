using EnglishNote.Application.Abtractions;

namespace EnglishNote.Infrastructure.Services;
internal sealed class GuidGenerator : IGuidGenerator
{
    public Guid NewGuid()
    {
        return Guid.CreateVersion7();
    }
}
