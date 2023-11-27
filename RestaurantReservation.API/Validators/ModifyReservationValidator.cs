using FluentValidation;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.API.Validators;

public class ModifyReservationValidator : AbstractValidator<ModifyReservationDto>
{
    public ModifyReservationValidator()
    {
        RuleFor(reservation => reservation.RestaurantId).NotNull();
        RuleFor(reservation => reservation.CustomerId).NotNull();
        RuleFor(reservation => reservation.PartySize).NotNull();
        RuleFor(reservation => reservation.TableId).NotNull();
        RuleFor(reservation => reservation.ReservationDate)
            .NotNull()
            .Must(reservationDate => DateTime.Compare(reservationDate, DateTime.Now) > 0)
            .WithMessage("'Reservation Date' must be in future");
    }
}