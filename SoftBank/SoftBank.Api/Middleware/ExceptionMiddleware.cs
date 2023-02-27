using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SoftBank.Core;
using SoftBank.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SoftBank.Api;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (BadParameterException ex)
        {
            _logger.LogError($"Parameter missing : {ex}");
            await HandleExceptionAsync(httpContext, ex);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var message = exception switch
        {
            BadParameterException => exception.Message,
            UnauthorizeAccessException => exception.Message,
            _ => "Internal Server Error from the custom middleware."
        };

        await context.Response.WriteAsync(new ErrorResponse()
        {
            StatusCode = context.Response.StatusCode,
            Message = message
        }.ToString());
    }
}
