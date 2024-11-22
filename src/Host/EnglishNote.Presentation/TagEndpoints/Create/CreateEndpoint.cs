﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EnglishNote.Presentation.TagEndpoints.Create;
internal class CreateEndpoint : IEndpoint
{
    public string EndpointName => EndpointSchema.Tag;

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("", async (CreateTagRequest request) =>
        {
            return "Ok";
        })
        .WithTags(EndpointSchema.Tag);
    }
}
