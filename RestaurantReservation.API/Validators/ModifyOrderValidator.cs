using FluentValidation;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.API.Validators;

public class ModifyOrderValidator : AbstractValidator<ModifyOrderDto>
{
    public ModifyOrderValidator()
    {
        RuleFor(order => order.EmployeeId).NotNull();
        RuleFor(order => order.ReservationId).NotNull();
    }
}