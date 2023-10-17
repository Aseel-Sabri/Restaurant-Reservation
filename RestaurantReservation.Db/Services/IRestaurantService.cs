using FluentResults;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.Db.Services;

public interface IRestaurantService
{
    Result<int> CreateRestaurant(RestaurantDto restaurantDto);
    Result<RestaurantDto> UpdateRestaurant(RestaurantDto restaurantDto);
    Result DeleteRestaurant(int restaurantId);
    Result<double> CalculateRestaurantTotalRevenue(int restaurantId);
}