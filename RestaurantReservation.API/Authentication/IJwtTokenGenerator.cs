namespace RestaurantReservation.API.Authentication;

public interface IJwtTokenGenerator
{
    Task<string?> GenerateToken(AuthenticationRequestBody authenticationRequestBody);
}