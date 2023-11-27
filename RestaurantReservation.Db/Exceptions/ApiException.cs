using System.Net;

namespace RestaurantReservation.Db.Exceptions;

public class ApiException : Exception
{
    public HttpStatusCode HttpStatusCode { get; init; } = HttpStatusCode.InternalServerError;

    public ApiException(string? message, Exception? e) : base(message, e)
    {
    }

    public ApiException(string? message) : base(message)
    {
    }
}