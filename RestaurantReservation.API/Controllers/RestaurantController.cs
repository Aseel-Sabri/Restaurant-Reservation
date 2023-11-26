using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers;

[Authorize]
[ApiController]
[Route("/api/restaurants")]
public class RestaurantController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;

    public RestaurantController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAllRestaurants()
    {
        return Ok(await _restaurantService.GetAllRestaurants());
    }

    [HttpGet("{restaurantId:int}")]
    public async Task<ActionResult<RestaurantDto>> GetRestaurant(int restaurantId)
    {
        return Ok(await _restaurantService.FindRestaurantById(restaurantId));
    }

    [HttpDelete("{restaurantId:int}")]
    public async Task<ActionResult> DeleteRestaurant(int restaurantId)
    {
        await _restaurantService.DeleteRestaurant(restaurantId);
        return NoContent();
    }

    [HttpPut("{restaurantId:int}")]
    public async Task<ActionResult<RestaurantDto>> UpdateRestaurant(int restaurantId, ModifyRestaurantDto restaurantDto)
    {
        return Ok(await _restaurantService.UpdateRestaurant(restaurantId, restaurantDto));
    }

    [HttpPost]
    public async Task<ActionResult> CreateRestaurant(ModifyRestaurantDto restaurantDto)
    {
        var restaurantId = await _restaurantService.CreateRestaurant(restaurantDto);
        return Ok(new { CreatedRestaurantId = restaurantId });
    }
}