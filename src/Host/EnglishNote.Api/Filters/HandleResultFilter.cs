using Microsoft.AspNetCore.Mvc;
using Shared;

namespace EnglishNote.Api.Filters;

public class HandleResultFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var result = await next(context);

        if (result is Result { IsFailure: true } error)
        {
            return Results.BadRequest(new ProblemDetails()
            {
                Title = "An error occurred while processing your request",
                Type = error.Error!.Code,
                Status = StatusCodes.Status400BadRequest,
                Detail = error.Error.Description
            });
        }

        return result;
    }
}
