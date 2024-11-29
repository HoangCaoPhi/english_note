using Microsoft.AspNetCore.Routing;

namespace EnglishNote.Presentation.Private.WordEndpoints.UpdateWord;
internal sealed class UpdateWordEndpoint : IPrivateEndpoint
{
    public string EndpointName => EndpointSchema.Word;

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        
    }
}
