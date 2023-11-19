using FluentResults;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.Db.Services;

public interface IRestaurantService
{
    Task<Result<int>> CreateRestaurant(RestaurantDto restaurantDto);
    Task<Result<RestaurantDto>> UpdateRestaurant(RestaurantDto restaurantDto);
    Task<Result> DeleteRestaurant(int restaurantId);
    Task<Result<double>> CalculateRestaurantTotalRevenue(int restaurantId);
}