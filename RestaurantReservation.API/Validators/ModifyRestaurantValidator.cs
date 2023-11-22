using FluentValidation;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.API.Validators;

public class ModifyRestaurantValidator : AbstractValidator<ModifyRestaurantDto>
{
    public ModifyRestaurantValidator()
    {
        RuleFor(restaurant => restaurant.OpeningHours)
            .NotEmpty()
            .Matches(@"^\d\d?:\d\d? - \d\d?:\d\d?$")
            .WithMessage("'Opening Hours' must be in the format 'HH:MM - HH:MM' in 24 format");

        RuleFor(restaurant => restaurant.PhoneNumber)
            .NotEmpty()
            .Matches(@"^[\d\s-]+$")
            .WithMessage("'PhoneNumber' should only consist of digits, hyphen, and spaces");

        RuleFor(restaurant => restaurant.Address).NotEmpty();

        RuleFor(restaurant => restaurant.Name).NotEmpty();
    }
}