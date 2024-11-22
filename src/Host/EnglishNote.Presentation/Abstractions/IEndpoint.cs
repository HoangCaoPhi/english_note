using Microsoft.AspNetCore.Routing;

namespace EnglishNote.Presentation.Abstractions;
public interface IEndpoint
{
    string EndpointName { get; }
    void MapEndpoint(IEndpointRouteBuilder app);
}
