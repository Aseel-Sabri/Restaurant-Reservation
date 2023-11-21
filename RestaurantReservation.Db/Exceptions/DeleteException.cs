namespace RestaurantReservation.Db.Exceptions;

public class DeleteException : Exception
{
    public DeleteException(string? message, Exception? e) : base(message, e)
    {
    }

    public DeleteException(string? message) : base(message)
    {
    }
}