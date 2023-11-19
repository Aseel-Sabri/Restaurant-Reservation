using RestaurantReservation.Db.KeylessEntities;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public interface IReservationRepository
{
    Task<int> CreateReservation(Reservation reservation);
    Task<Reservation> UpdateReservation(Reservation reservation);
    Task<bool> DeleteReservation(int reservationId);
    Task<Reservation?> FindReservationById(int reservationId);
    Task<bool> HasReservationById(int reservationId);
    Task<List<Reservation>> GetReservationsByCustomer(int customerId);
    Task<List<ReservationDetails>> GetReservationsWithCustomerAndRestaurantDetails();
}