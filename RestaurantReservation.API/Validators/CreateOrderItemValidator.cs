using FluentValidation;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.API.Validators;

public class CreateOrderItemValidator : AbstractValidator<CreateOrderItemDto>
{
    public CreateOrderItemValidator()
    {
        RuleFor(orderItem => orderItem.MenuItemId).NotNull();
        RuleFor(orderItem => orderItem.Quantity).NotNull();
    }
}