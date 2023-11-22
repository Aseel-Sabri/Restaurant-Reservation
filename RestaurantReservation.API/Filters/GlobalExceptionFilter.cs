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
        var message = "Internal Server Error";
        var statusCode = (int)HttpStatusCode.InternalServerError;

        switch (exception)
        {
            case ApiException apiException:
                message = apiException.Message;
                statusCode = (int)apiException.HttpStatusCode;
                context.ExceptionHandled = true;
                break;
            default:
                _logger.LogError(
                    $"GlobalExceptionFilter: Error in {context.ActionDescriptor.DisplayName}. {exception.Message}. Stack Trace: {exception.StackTrace}");
                break;
        }

        context.Result = new ObjectResult(new
        {
            Status = statusCode,
            Title = "Error",
            Message = message
        })
        {
            StatusCode = statusCode
        };
    }
}