using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.Db.Services;

public interface IRestaurantService
{
    Task<int> CreateRestaurant(ModifyRestaurantDto restaurantDto);
    Task<RestaurantDto> UpdateRestaurant(int restaurantId, ModifyRestaurantDto restaurantDto);
    Task DeleteRestaurant(int restaurantId);
    Task<double> CalculateRestaurantTotalRevenue(int restaurantId);
    Task<IEnumerable<RestaurantDto>> GetAllRestaurants();
    Task<RestaurantDto> FindRestaurantById(int restaurantId);
}