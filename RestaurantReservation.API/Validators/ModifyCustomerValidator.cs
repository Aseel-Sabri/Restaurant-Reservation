using FluentValidation;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.API.Validators;

public class ModifyCustomerValidator : AbstractValidator<ModifyCustomerDto>
{
    public ModifyCustomerValidator()
    {
        RuleFor(customer => customer.FirstName).NotEmpty();

        RuleFor(customer => customer.LastName).NotEmpty();

        RuleFor(customer => customer.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(customer => customer.PhoneNumber)
            .NotEmpty()
            .Matches(@"^[\d\s-]+$")
            .WithMessage("PhoneNumber should only consist of digits, hyphen, and spaces");
    }
}