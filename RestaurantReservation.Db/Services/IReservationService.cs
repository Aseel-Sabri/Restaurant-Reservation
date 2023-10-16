using FluentResults;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.KeylessEntities;

namespace RestaurantReservation.Db.Services;

public interface IReservationService
{
    Result<int> CreateReservation(ReservationDto reservationDto);
    Result<ReservationDto> UpdateReservation(ReservationDto reservationDto);
    Result DeleteReservation(int reservationId);
    Result<List<ReservationDto>> GetReservationsByCustomer(int customerId);
    List<ReservationDetails> GetReservationsWithCustomerAndRestaurantDetails();
}