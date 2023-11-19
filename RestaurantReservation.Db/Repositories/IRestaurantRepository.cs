using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public interface IRestaurantRepository
{
    Task<int> CreateRestaurant(Restaurant restaurant);
    Task<Restaurant> UpdateRestaurant(Restaurant restaurant);
    Task<bool> DeleteRestaurant(int restaurantId);
    Task<Restaurant?> FindRestaurantById(int restaurantId);
    Task<bool> HasRestaurantById(int restaurantId);
    Task<double> CalculateRestaurantTotalRevenue(int restaurantId);
}