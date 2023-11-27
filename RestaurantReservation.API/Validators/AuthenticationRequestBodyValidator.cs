using FluentValidation;
using RestaurantReservation.API.Authentication;

namespace RestaurantReservation.API.Validators;

public class AuthenticationRequestBodyValidator : AbstractValidator<AuthenticationRequestBody>
{
    public AuthenticationRequestBodyValidator()
    {
        RuleFor(requestBody => requestBody.Username).NotEmpty();
        RuleFor(requestBody => requestBody.Password).NotEmpty();
    }
}