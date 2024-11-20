using EnglishNote.Domain.Users;

namespace EnglishNote.Domain.Tags;

public class Tag
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public Guid UserId { get; private set; }
    public ApplicationUser User { get; private set; }
 
    private Tag() { }

    public Tag(string name, ApplicationUser user)
    {
        Id = Guid.CreateVersion7();
        Name = name;
        UserId = user.Id; 
    }
  
    public void UpdateName(string name)
    {
        Name = name;
    }
}
