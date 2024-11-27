using EnglishNote.Domain.AggregatesModel.Identity;
using EnglishNote.Domain.AggregatesModel.Words;
using EnglishNote.Domain.SeedWork;

namespace EnglishNote.Domain.AggregatesModel.Tags;

public class Tag : AggregateRoot
{
    public string Name { get; private set; }

    public string Description { get; private set; }

    public Guid UserId { get; private set; }
    public ApplicationUser User { get; private set; }

    public IReadOnlyCollection<Word> Words => _words.AsReadOnly();

    private readonly List<Word> _words = [];

    private Tag() { }

    public static Tag CreateTag(Guid id,
        string name, 
        string? description, 
        Guid userId)
    {
        return new Tag()
        {
            Id = id,
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
