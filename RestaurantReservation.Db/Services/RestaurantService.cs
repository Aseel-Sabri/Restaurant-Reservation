using AutoMapper;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Exceptions;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services;

public class RestaurantService : IRestaurantService
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IMapper _mapper;

    public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
    {
        _restaurantRepository = restaurantRepository;
        _mapper = mapper;
    }

    public async Task<int> CreateRestaurant(ModifyRestaurantDto restaurantDto)
    {
        var restaurant = _mapper.Map<Restaurant>(restaurantDto);
        var restaurantId = await _restaurantRepository.CreateRestaurant(restaurant);
        return restaurantId;
    }

    public async Task<RestaurantDto> UpdateRestaurant(int restaurantId, ModifyRestaurantDto restaurantDto)
    {
        var restaurant = await _restaurantRepository.FindRestaurantById(restaurantId);
        if (restaurant is null)
            throw new NotFoundException($"No Restaurant with ID {restaurantId} Exists");

        _mapper.Map(restaurantDto, restaurant);

        var updatedRestaurant = await _restaurantRepository.UpdateRestaurant(restaurant);
        return _mapper.Map<RestaurantDto>(updatedRestaurant);
    }

    public async Task DeleteRestaurant(int restaurantId)
    {
        if (!await _restaurantRepository.HasRestaurantById(restaurantId))
            throw new NotFoundException($"No Restaurant With ID {restaurantId} Exists");

        try
        {
            if (!await _restaurantRepository.DeleteRestaurant(restaurantId))
                throw new ApiException($"Could Not Delete Restaurant With ID {restaurantId}");
        }
        catch (Exception e)
        {
            throw new ApiException(
                $"Could Not Delete Restaurant With ID {restaurantId}, It May Have Related Data", e);
        }
    }

    public async Task<double> CalculateRestaurantTotalRevenue(int restaurantId)
    {
        if (!await _restaurantRepository.HasRestaurantById(restaurantId))
            throw new NotFoundException($"No Restaurant With ID {restaurantId} Exists");

        return await _restaurantRepository.CalculateRestaurantTotalRevenue(restaurantId);
    }

    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        var restaurants = await _restaurantRepository.GetAllRestaurants();
        return _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
    }

    public async Task<RestaurantDto> FindRestaurantById(int restaurantId)
    {
        var restaurant = await _restaurantRepository.FindRestaurantById(restaurantId);
        if (restaurant is null)
            throw new NotFoundException($"No Restaurant with ID {restaurantId} Exists");

        return _mapper.Map<RestaurantDto>(restaurant);
    }
}