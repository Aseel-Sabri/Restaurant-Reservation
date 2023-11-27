using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.DbContext;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly RestaurantReservationDbContext _dbContext;

    public RestaurantRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateRestaurant(Restaurant restaurant)
    {
        await _dbContext.Restaurants.AddAsync(restaurant);
        await _dbContext.SaveChangesAsync();
        return restaurant.RestaurantId;
    }

    public async Task<Restaurant> UpdateRestaurant(Restaurant restaurant)
    {
        _dbContext.Entry(restaurant).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return await FindRestaurantById(restaurant.RestaurantId);
    }

    public async Task<bool> DeleteRestaurant(int restaurantId)
    {
        var restaurant = await FindRestaurantById(restaurantId);
        _dbContext.Restaurants.Remove(restaurant);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<double> CalculateRestaurantTotalRevenue(int restaurantId)
    {
        return (double)await _dbContext.Restaurants
            .Select(_ => _dbContext.RestaurantTotalRevenue(restaurantId))
            .FirstOrDefaultAsync();
    }

    public async Task<Restaurant?> FindRestaurantById(int restaurantId)
    {
        return await _dbContext.Restaurants.FindAsync(restaurantId);
    }

    public async Task<bool> HasRestaurantById(int restaurantId)
    {
        return await FindRestaurantById(restaurantId) is not null;
    }

    public async Task<List<Restaurant>> GetAllRestaurants()
    {
        return await _dbContext.Restaurants.ToListAsync();
    }
}