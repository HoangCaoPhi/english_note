using BuildingBlocks.Domain;
using EnglishNote.Domain.Identity;
using EnglishNote.Domain.Words;

namespace EnglishNote.Domain.Tags;

public class Tag : AggregateRoot
{
    public string Name { get; private set; }

    public string Description { get; private set; }

    public Guid UserId { get; private set; }
    public ApplicationUser User { get; private set; }

    public IReadOnlyCollection<Word> Words => _words.AsReadOnly();

    private readonly List<Word> _words = [];

    private Tag() { }

    public static Tag CreateTag(string name, string? description, Guid userId)
    {
        return new Tag()
        {
            Id = Guid.CreateVersion7(),
            Name = name,
            Description = description,
            UserId = userId
        };
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
}
