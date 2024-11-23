namespace EnglishNote.Application.Abtractions.Authentication;
public interface IIdentityService
{
    Guid GetUserIdentity();

    string? GetUserName();
}
