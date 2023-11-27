using FluentValidation;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.API.Validators;

public class UpdateMenuItemValidator : AbstractValidator<UpdateMenuItemDto>
{
    public UpdateMenuItemValidator()
    {
        RuleFor(item => item.Description).NotEmpty();
        RuleFor(item => item.Name).NotEmpty();
        RuleFor(item => item.Price).NotNull();
    }
}