using FluentValidation;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.API.Validators;

public class UpdateTableValidator : AbstractValidator<UpdateTableDto>
{
    public UpdateTableValidator()
    {
        RuleFor(table => table.Capacity).NotNull();
    }
}