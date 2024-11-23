using EnglishNote.Application.Abtractions.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EnglishNote.Infrastructure.Authentication;
public class IdentityService(IHttpContextAccessor context) : IIdentityService
{
    public Guid GetUserIdentity()
    {
        string? userId = context.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var guid))
            throw new InvalidOperationException("User identity is invalid or not present.");
        return guid;
    }


    public string? GetUserName()
        => context.HttpContext?.User.Identity?.Name;
}
