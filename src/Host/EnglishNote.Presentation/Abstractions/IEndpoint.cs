using Microsoft.AspNetCore.Routing;

namespace EnglishNote.Presentation.Abstractions;
internal interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
