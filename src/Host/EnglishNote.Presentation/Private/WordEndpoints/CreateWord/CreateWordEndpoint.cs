using EnglishNote.Application.UseCases.Words.CreateWord;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace EnglishNote.Presentation.Private.WordEndpoints.CreateWord;
internal class CreateWordEndpoint : IPrivateEndpoint
{
    public string EndpointName => EndpointSchema.Word;

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("", async (
            CreateWordRequest request,
            IMapper mapper, 
            ISender sender) =>
        {
            var command = mapper.Map<CreateWordCommand>(request);
            return await sender.Send(command);
        });
    }
}
