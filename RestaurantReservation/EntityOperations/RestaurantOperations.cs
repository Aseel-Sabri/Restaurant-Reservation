using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.EntityOperations;

public class RestaurantOperations
{
    private readonly IRestaurantService _restaurantService;

    public RestaurantOperations(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    public async Task CreateRestaurant()
    {
        var restaurantDto = new RestaurantDto()
        {
            Name = "ABC",
            Address = "XYZ",
            OpeningHours = "08:00 - 21:00",
            PhoneNumber = "111-2222"
        };

        var result = await _restaurantService.CreateRestaurant(restaurantDto);
        if (result.IsSuccess)
        {
            var createdRestaurantId = result.Value;
            Console.WriteLine($"Restaurant Added With ID {createdRestaurantId}");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public async Task UpdateRestaurant()
    {
        var restaurantDto = new RestaurantDto()
        {
            RestaurantId = 1,
            OpeningHours = "09:00 - 23:00"
        };

        var result = await _restaurantService.UpdateRestaurant(restaurantDto);
        if (result.IsSuccess)
        {
            Console.WriteLine($"Updated Restaurant: {Environment.NewLine}{result.Value}");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public async Task DeleteRestaurant(int restaurantId)
    {
        var result = await _restaurantService.DeleteRestaurant(restaurantId);

        if (result.IsSuccess)
        {
            Console.WriteLine($"Restaurant With ID {restaurantId} Deleted Successfully");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public async Task CalculateRestaurantTotalRevenue(int restaurantId)
    {
        var result = await _restaurantService.CalculateRestaurantTotalRevenue(restaurantId);
        if (result.IsFailed)
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
            Console.WriteLine();
            return;
        }


        Console.WriteLine($"Revenue Of Restaurant With ID {restaurantId} = {result.Value}");
        Console.WriteLine();
    }
}