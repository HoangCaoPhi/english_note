using Microsoft.AspNetCore.Identity;

namespace EnglishNote.Domain.Users;
public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}
