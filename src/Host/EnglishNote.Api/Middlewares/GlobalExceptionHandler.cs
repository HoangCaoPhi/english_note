using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EnglishNote.Api.Middlewares;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger,
    IHostEnvironment hostEnvironment) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = new ProblemDetails()
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "An unexpected error occurred",
            Type = "ServerError",
            Detail = "An error occurred while processing your request. Please try again later."
        };

        if (hostEnvironment.IsDevelopment())
        {
            problemDetails.Extensions = new Dictionary<string, object?>()
            {
                ["errors"] = exception.Message
            };
        }

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken).ConfigureAwait(false);

        logger.LogError(exception, "An unexpected error occurred while processing the request.");

        return true;
    }
}
