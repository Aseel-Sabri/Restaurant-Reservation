﻿using FluentValidation;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.API.Validators;

public class ModifyEmployeeValidator : AbstractValidator<ModifyEmployeeDto>
{
    public ModifyEmployeeValidator()
    {
        RuleFor(employeeDto => employeeDto.FirstName)
            .NotEmpty();

        RuleFor(employeeDto => employeeDto.LastName)
            .NotEmpty();

        RuleFor(employeeDto => employeeDto.RestaurantId)
            .NotNull();
            // .ExclusiveBetween(1, 4);

        RuleFor(employeeDto => employeeDto.Position)
            .NotNull();
            // .IsInEnum()
    }
}