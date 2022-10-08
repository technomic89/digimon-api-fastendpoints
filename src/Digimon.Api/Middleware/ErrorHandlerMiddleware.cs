using System.Net;
using System.Text.Json;
using Digimon.Application.Common.Exceptions;

namespace Digimon.Api.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    
    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case UnauthorizedAccessException e:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    case AppException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case NotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        var r = e.Errors.Values.Aggregate(error.Message, (current1, ar) => ar.Aggregate(current1, (current, ex) => $"{current} {ex}"));
                        await response.WriteAsync(JsonSerializer.Serialize(new { message = r }));
                        return;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = error.Message });
                await response.WriteAsync(result);
            }
        }
}