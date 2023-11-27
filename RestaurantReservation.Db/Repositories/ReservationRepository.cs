using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.DbContext;
using RestaurantReservation.Db.KeylessEntities;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly RestaurantReservationDbContext _dbContext;

    public ReservationRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateReservation(Reservation reservation)
    {
        await _dbContext.Reservations.AddAsync(reservation);
        await _dbContext.SaveChangesAsync();
        return reservation.ReservationId;
    }

    public async Task<Reservation> UpdateReservation(Reservation reservation)
    {
        _dbContext.Entry(reservation).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return await FindReservationById(reservation.ReservationId);
    }

    public async Task<bool> DeleteReservation(int reservationId)
    {
        var reservation = await _dbContext.Reservations.FindAsync(reservationId);
        _dbContext.Reservations.Remove(reservation);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<List<Reservation>> GetReservationsByCustomer(int customerId)
    {
        return await _dbContext.Reservations.Where(reservation => reservation.CustomerId == customerId).ToListAsync();
    }

    public async Task<List<ReservationDetails>> GetReservationsWithCustomerAndRestaurantDetails()
    {
        return await _dbContext.ReservationsDetails.ToListAsync();
    }

    public async Task<Reservation?> FindReservationById(int reservationId)
    {
        return await _dbContext.Reservations.FindAsync(reservationId);
    }

    public async Task<bool> HasReservationById(int reservationId)
    {
        return await FindReservationById(reservationId) is not null;
    }
}