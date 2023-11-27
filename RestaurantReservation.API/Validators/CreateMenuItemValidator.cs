using FluentValidation;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.API.Validators;

public class CreateMenuItemValidator : AbstractValidator<CreateMenuItemDto>
{
    public CreateMenuItemValidator()
    {
        RuleFor(item => item.RestaurantId).NotNull();
        RuleFor(item => item.Description).NotEmpty();
        RuleFor(item => item.Name).NotEmpty();
        RuleFor(item => item.Price).NotNull();
    }
}