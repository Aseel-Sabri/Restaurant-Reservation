using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RestaurantReservation.Db.Exceptions;

namespace RestaurantReservation.API.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    private readonly ILogger<GlobalExceptionFilter> _logger;

    public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        if (context.ExceptionHandled) return;

        var exception = context.Exception;
        string? message = null;
        var statusCode = HttpStatusCode.InternalServerError;

        switch (exception)
        {
            case ApiException apiException:
                message = apiException.Message;
                statusCode = apiException.HttpStatusCode;
                context.ExceptionHandled = true;
                break;
            default:
                _logger.LogError(
                    $"GlobalExceptionFilter: Error in {context.ActionDescriptor.DisplayName}. {exception.Message}. Stack Trace: {exception.StackTrace}");
                break;
        }

        var problemDetails = new ProblemDetails()
        {
            Status = (int)statusCode,
            Title = statusCode.ToString(),
            Detail = message
        };

        context.Result = new ObjectResult(problemDetails)
        {
            StatusCode = (int)statusCode
        };
    }
}