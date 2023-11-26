using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;
using RestaurantReservation.Db.ValueObjects;

namespace RestaurantReservation.API.Controllers;

[Authorize]
[ApiController]
[Route("/api/reservations")]
public class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;
    private readonly IMenuItemService _menuItemService;
    private readonly IOrderService _orderService;

    public ReservationController(IReservationService reservationService, IMenuItemService menuItemService,
        IOrderService orderService)
    {
        _reservationService = reservationService;
        _menuItemService = menuItemService;
        _orderService = orderService;
    }

    /// <summary>
    /// Gets a list of all reservations.
    /// </summary>
    /// <returns>A list of reservation DTOs.</returns>
    /// <response code="200">Returns a list of reservations.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReservationDto>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservations()
    {
        return Ok(await _reservationService.GetAllReservations());
    }

    /// <summary>
    /// Gets a reservation by ID.
    /// </summary>
    /// <param name="reservationId">The ID of the reservation.</param>
    /// <returns>The reservation DTO.</returns>
    /// <response code="200">Returns the requested reservation.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReservationDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet("{reservationId:int}")]
    public async Task<ActionResult<ReservationDto>> GetReservation(int reservationId)
    {
        return Ok(await _reservationService.FindReservationById(reservationId));
    }

    /// <summary>
    /// Deletes a reservation by ID.
    /// </summary>
    /// <param name="reservationId">The ID of the reservation to delete.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">No content if the deletion is successful.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpDelete("{reservationId:int}")]
    public async Task<ActionResult> DeleteReservation(int reservationId)
    {
        await _reservationService.DeleteReservation(reservationId);
        return NoContent();
    }

    /// <summary>
    /// Updates a reservation by ID.
    /// </summary>
    /// <param name="reservationId">The ID of the reservation to update.</param>
    /// <param name="reservationDto">The updated reservation DTO.</param>
    /// <returns>The updated reservation DTO.</returns>
    /// <response code="200">Returns the updated reservation.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReservationDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPut("{reservationId:int}")]
    public async Task<ActionResult<ReservationDto>> UpdateReservation(int reservationId,
        ModifyReservationDto reservationDto)
    {
        return Ok(await _reservationService.UpdateReservation(reservationId, reservationDto));
    }

    /// <summary>
    /// Creates a new reservation.
    /// </summary>
    /// <param name="reservationDto">The reservation DTO for creation.</param>
    /// <returns>The ID of the created reservation.</returns>
    /// <response code="200">Returns the ID of the created reservation.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost]
    public async Task<ActionResult> CreateReservation(ModifyReservationDto reservationDto)
    {
        var reservationId = await _reservationService.CreateReservation(reservationDto);
        return Ok(new { CreatedReservationId = reservationId });
    }

    /// <summary>
    /// Gets a list of reservations by customer ID.
    /// </summary>
    /// <param name="customerId">The ID of the customer.</param>
    /// <returns>A list of reservation DTOs for the specified customer.</returns>
    /// <response code="200">Returns a list of reservations for the customer.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReservationDto>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("customer/{customerId:int}")]
    public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservationsByCustomer(int customerId)
    {
        return Ok(await _reservationService.GetReservationsByCustomer(customerId));
    }

    /// <summary>
    /// Gets a list of menu items ordered within a reservation.
    /// </summary>
    /// <param name="reservationId">The ID of the reservation.</param>
    /// <returns>A list of ordered menu item DTOs.</returns>
    /// <response code="200">Returns a list of ordered menu items within the reservation.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MenuItemDto>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{reservationId:int}/menu-items")]
    public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetOrderedMenuItems(int reservationId)
    {
        return Ok(await _menuItemService.ListOrderedMenuItems(reservationId));
    }

    /// <summary>
    /// Gets a list of orders and menu items within a reservation.
    /// </summary>
    /// <param name="reservationId">The ID of the reservation.</param>
    /// <returns>A list of orders and menu items DTOs within the reservation.</returns>
    /// <response code="200">Returns a list of orders and menu items within the reservation.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrdersAndMenuItems>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{reservationId:int}/orders")]
    public async Task<ActionResult<IEnumerable<OrdersAndMenuItems>>> GetOrdersAndMenuItems(int reservationId)
    {
        return Ok(await _orderService.ListOrdersAndMenuItems(reservationId));
    }
}