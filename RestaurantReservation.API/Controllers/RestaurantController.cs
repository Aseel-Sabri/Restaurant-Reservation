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

    /// <summary>
    /// Gets a list of all restaurants.
    /// </summary>
    /// <returns>A list of restaurant DTOs.</returns>
    /// <response code="200">Returns a list of restaurants.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RestaurantDto>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAllRestaurants()
    {
        return Ok(await _restaurantService.GetAllRestaurants());
    }

    /// <summary>
    /// Gets a restaurant by ID.
    /// </summary>
    /// <param name="restaurantId">The ID of the restaurant.</param>
    /// <returns>The restaurant DTO.</returns>
    /// <response code="200">Returns the requested restaurant.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RestaurantDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet("{restaurantId:int}")]
    public async Task<ActionResult<RestaurantDto>> GetRestaurant(int restaurantId)
    {
        return Ok(await _restaurantService.FindRestaurantById(restaurantId));
    }

    /// <summary>
    /// Deletes a restaurant by ID.
    /// </summary>
    /// <param name="restaurantId">The ID of the restaurant to delete.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">No content if the deletion is successful.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpDelete("{restaurantId:int}")]
    public async Task<ActionResult> DeleteRestaurant(int restaurantId)
    {
        await _restaurantService.DeleteRestaurant(restaurantId);
        return NoContent();
    }

    /// <summary>
    /// Updates a restaurant by ID.
    /// </summary>
    /// <param name="restaurantId">The ID of the restaurant to update.</param>
    /// <param name="restaurantDto">The updated restaurant DTO.</param>
    /// <returns>The updated restaurant DTO.</returns>
    /// <response code="200">Returns the updated restaurant.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RestaurantDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPut("{restaurantId:int}")]
    public async Task<ActionResult<RestaurantDto>> UpdateRestaurant(int restaurantId, ModifyRestaurantDto restaurantDto)
    {
        return Ok(await _restaurantService.UpdateRestaurant(restaurantId, restaurantDto));
    }

    /// <summary>
    /// Creates a new restaurant.
    /// </summary>
    /// <param name="restaurantDto">The restaurant DTO for creation.</param>
    /// <returns>The ID of the created restaurant.</returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost]
    public async Task<ActionResult> CreateRestaurant(ModifyRestaurantDto restaurantDto)
    {
        var restaurantId = await _restaurantService.CreateRestaurant(restaurantDto);
        return Ok(new { CreatedRestaurantId = restaurantId });
    }
}