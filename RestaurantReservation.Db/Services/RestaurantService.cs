using FluentResults;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services;

public class RestaurantService : IRestaurantService
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantService(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }

    public async Task<Result<int>> CreateRestaurant(RestaurantDto restaurantDto)
    {
        if (restaurantDto.HasAnyNullOrEmptyFields())
        {
            return Result.Fail($"All Restaurant Fields Must Be Provided");
        }

        var restaurant = new Restaurant()
        {
            RestaurantId = restaurantDto.RestaurantId,
            Address = restaurantDto.Address,
            OpeningHours = restaurantDto.OpeningHours,
            PhoneNumber = restaurantDto.PhoneNumber,
            Name = restaurantDto.Name
        };
        var restaurantId = await _restaurantRepository.CreateRestaurant(restaurant);
        return Result.Ok(restaurantId);
    }

    public async Task<Result<RestaurantDto>> UpdateRestaurant(RestaurantDto restaurantDto)
    {
        var restaurant = await _restaurantRepository.FindRestaurantById(restaurantDto.RestaurantId);
        if (restaurant is null)
            return Result.Fail($"No Restaurant with ID {restaurantDto.RestaurantId} Exists");

        restaurant.Name = restaurantDto.Name ?? restaurant.Name;
        restaurant.Address = restaurantDto.Address ?? restaurant.Address;
        // TODO: Validate phone number & opening hours format
        restaurant.PhoneNumber = restaurantDto.PhoneNumber ?? restaurant.PhoneNumber;
        restaurant.OpeningHours = restaurantDto.OpeningHours ?? restaurant.OpeningHours;

        var updatedRestaurant = await _restaurantRepository.UpdateRestaurant(restaurant);
        return Result.Ok(MapToRestaurantDto(updatedRestaurant));
    }

    public async Task<Result> DeleteRestaurant(int restaurantId)
    {
        if (!await _restaurantRepository.HasRestaurantById(restaurantId))
            return Result.Fail($"No Restaurant With ID {restaurantId} Exists");

        try
        {
            return Result.OkIf(await _restaurantRepository.DeleteRestaurant(restaurantId),
                $"Could Not Delete Restaurant With ID {restaurantId}");
        }
        catch (Exception e)
        {
            return Result.Fail(
                $"Could Not Delete Restaurant With ID {restaurantId}, It May Have Related Data");
        }
    }

    public async Task<Result<double>> CalculateRestaurantTotalRevenue(int restaurantId)
    {
        if (!await _restaurantRepository.HasRestaurantById(restaurantId))
            return Result.Fail($"No Restaurant With ID {restaurantId} Exists");

        return await _restaurantRepository.CalculateRestaurantTotalRevenue(restaurantId);
    }

    private RestaurantDto MapToRestaurantDto(Restaurant restaurant)
    {
        return new RestaurantDto()
        {
            RestaurantId = restaurant.RestaurantId,
            Address = restaurant.Address,
            OpeningHours = restaurant.OpeningHours,
            PhoneNumber = restaurant.PhoneNumber,
            Name = restaurant.Name
        };
    }
}