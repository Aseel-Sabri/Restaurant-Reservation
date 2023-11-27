using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;

namespace RestaurantReservation.API.Validators;

public class ValidationResultFactory : IFluentValidationAutoValidationResultFactory
{
    public IActionResult CreateActionResult(ActionExecutingContext context,
        ValidationProblemDetails? validationProblemDetails)
    {
        return new BadRequestObjectResult(new
        {
            Status = 400,
            Title = "Validation errors",
            ValidationErrors = validationProblemDetails?.Errors
        });
    }
}