namespace RestaurantReservation.API.Authentication;

public class AuthenticationRequestBody
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}