using FluentValidation;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.API.Validators;

public class CreateTableValidator : AbstractValidator<CreateTableDto>
{
    public CreateTableValidator()
    {
        RuleFor(table => table.Capacity).NotNull();
        RuleFor(table => table.RestaurantId).NotNull();
    }    
}