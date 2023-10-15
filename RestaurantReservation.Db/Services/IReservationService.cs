using FluentResults;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.Db.Services;

public interface IReservationService
{
    Result<int> CreateReservation(ReservationDto reservationDto);
    Result<ReservationDto> UpdateReservation(ReservationDto reservationDto);
    Result DeleteReservation(int reservationId);
}