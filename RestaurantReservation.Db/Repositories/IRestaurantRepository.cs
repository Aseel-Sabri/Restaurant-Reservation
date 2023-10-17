using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public interface IRestaurantRepository
{
    int CreateRestaurant(Restaurant restaurant);
    Restaurant UpdateRestaurant(Restaurant restaurant);
    bool DeleteRestaurant(int restaurantId);
    Restaurant? FindRestaurantById(int restaurantId);
    bool HasRestaurantById(int restaurantId);
    double CalculateRestaurantTotalRevenue(int restaurantId);
}