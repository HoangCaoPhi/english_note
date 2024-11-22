using BuildingBlocks.Domain;
using EnglishNote.Domain.Users;
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

    public Tag(string name, string? description, ApplicationUser user)
    {
        Id = Guid.CreateVersion7();
        Name = name;
        Description = description;
        UserId = user.Id; 
    }
  
    public void UpdateName(string name)
    {
        Name = name;
    }
}
