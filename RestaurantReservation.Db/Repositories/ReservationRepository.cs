using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly RestaurantReservationDbContext _dbContext;

    public ReservationRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int CreateReservation(Reservation reservation)
    {
        _dbContext.Reservations.Add(reservation);
        _dbContext.SaveChanges();
        return reservation.ReservationId;
    }

    public Reservation UpdateReservation(Reservation reservation)
    {
        _dbContext.Entry(reservation).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return FindReservationById(reservation.ReservationId);
    }

    public bool DeleteReservation(int reservationId)
    {
        var reservation = _dbContext.Reservations.Find(reservationId);
        _dbContext.Reservations.Remove(reservation);
        return _dbContext.SaveChanges() > 0;
    }

    public Reservation? FindReservationById(int reservationId)
    {
        return _dbContext.Reservations.Find(reservationId);
    }

    public bool HasReservationById(int reservationId)
    {
        return FindReservationById(reservationId) is not null;
    }
}