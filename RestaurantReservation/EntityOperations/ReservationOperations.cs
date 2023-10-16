using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.EntityOperations;

public class ReservationOperations
{
    private readonly IReservationService _reservationService;

    public ReservationOperations(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    public void CreateReservation()
    {
        var reservationDto = new ReservationDto()
        {
            RestaurantId = 1,
            CustomerId = 1,
            ReservationDate = DateTime.Today,
            TableId = 1,
            PartySize = 4
        };


        var result = _reservationService.CreateReservation(reservationDto);
        if (result.IsSuccess)
        {
            var createdReservationId = result.Value;
            Console.WriteLine($"Reservation Added With ID {createdReservationId}");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public void UpdateReservation()
    {
        var reservationDto = new ReservationDto()
        {
            ReservationId = 1,
            CustomerId = 3
        };

        var result = _reservationService.UpdateReservation(reservationDto);
        if (result.IsSuccess)
        {
            Console.WriteLine($"Updated Reservation: {Environment.NewLine}{result.Value}");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public void DeleteReservation(int reservationId)
    {
        var result = _reservationService.DeleteReservation(reservationId);

        if (result.IsSuccess)
        {
            Console.WriteLine($"Reservation With ID {reservationId} Deleted Successfully");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public void GetReservationsByCustomer(int customerId)
    {
        var result = _reservationService.GetReservationsByCustomer(customerId);
        if (result.IsFailed)
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
            Console.WriteLine();
            return;
        }

        var reservations = result.Value;

        if (!reservations.Any())
        {
            Console.WriteLine($"No Reservations Were Made By Customer With ID {customerId}");
            return;
        }

        reservations.ForEach(reservation =>
        {
            Console.WriteLine(reservation);
            Console.WriteLine();
        });
    }
}