namespace BuildingBlocks;
public interface IIdentityService
{
    Guid GetUserIdentity();

    string? GetUserName();
}
