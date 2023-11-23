using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.ValueObjects;

namespace RestaurantReservation.Db.Services;

public interface IReservationService
{
    Task<int> CreateReservation(ModifyReservationDto reservationDto);
    Task<ReservationDto> UpdateReservation(int reservationId, ModifyReservationDto reservationDto);
    Task DeleteReservation(int reservationId);
    Task<IEnumerable<ReservationDto>> GetReservationsByCustomer(int customerId);
    Task<IEnumerable<ReservationDetails>> GetReservationsWithCustomerAndRestaurantDetails();
    Task<IEnumerable<ReservationDto>> GetAllReservations();
    Task<ReservationDto> FindReservationById(int reservationId);
}