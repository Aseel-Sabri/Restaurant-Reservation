using RestaurantReservation.Db.KeylessEntities;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public interface IReservationRepository
{
    int CreateReservation(Reservation reservation);
    Reservation UpdateReservation(Reservation reservation);
    bool DeleteReservation(int reservationId);
    Reservation? FindReservationById(int reservationId);
    bool HasReservationById(int reservationId);
    List<Reservation> GetReservationsByCustomer(int customerId);
    List<ReservationDetails> GetReservationsWithCustomerAndRestaurantDetails();
}