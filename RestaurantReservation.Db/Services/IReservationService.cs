using FluentResults;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.KeylessEntities;

namespace RestaurantReservation.Db.Services;

public interface IReservationService
{
    Task<Result<int>> CreateReservation(ReservationDto reservationDto);
    Task<Result<ReservationDto>> UpdateReservation(ReservationDto reservationDto);
    Task<Result> DeleteReservation(int reservationId);
    Task<Result<List<ReservationDto>>> GetReservationsByCustomer(int customerId);
    Task<List<ReservationDetails>> GetReservationsWithCustomerAndRestaurantDetails();
}