using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly RestaurantReservationDbContext _dbContext;

    public RestaurantRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int CreateRestaurant(Restaurant restaurant)
    {
        _dbContext.Restaurants.Add(restaurant);
        _dbContext.SaveChanges();
        return restaurant.RestaurantId;
    }

    public Restaurant UpdateRestaurant(Restaurant restaurant)
    {
        _dbContext.Entry(restaurant).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return FindRestaurantById(restaurant.RestaurantId);
    }

    public bool DeleteRestaurant(int restaurantId)
    {
        var restaurant = FindRestaurantById(restaurantId);
        _dbContext.Restaurants.Remove(restaurant);
        return _dbContext.SaveChanges() > 0;
    }

    public Restaurant? FindRestaurantById(int restaurantId)
    {
        return _dbContext.Restaurants.Find(restaurantId);
    }

    public bool HasRestaurantById(int restaurantId)
    {
        return FindRestaurantById(restaurantId) is not null;
    }
}