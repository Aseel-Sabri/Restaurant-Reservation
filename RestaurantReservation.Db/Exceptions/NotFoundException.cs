using System.Net;

namespace RestaurantReservation.Db.Exceptions;

public class NotFoundException : ApiException
{
    public NotFoundException(string? message) : base(message)
    {
        HttpStatusCode = HttpStatusCode.NotFound;
    }
}