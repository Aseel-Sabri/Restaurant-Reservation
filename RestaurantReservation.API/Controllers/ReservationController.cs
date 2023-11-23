using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;
using RestaurantReservation.Db.ValueObjects;

namespace RestaurantReservation.API.Controllers;

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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservations()
    {
        return Ok(await _reservationService.GetAllReservations());
    }

    [HttpGet("{reservationId:int}")]
    public async Task<ActionResult<ReservationDto>> GetReservation(int reservationId)
    {
        return Ok(await _reservationService.FindReservationById(reservationId));
    }

    [HttpDelete("{reservationId:int}")]
    public async Task<ActionResult> DeleteReservation(int reservationId)
    {
        await _reservationService.DeleteReservation(reservationId);
        return NoContent();
    }

    [HttpPut("{reservationId:int}")]
    public async Task<ActionResult<ReservationDto>> UpdateReservation(int reservationId,
        ModifyReservationDto reservationDto)
    {
        return Ok(await _reservationService.UpdateReservation(reservationId, reservationDto));
    }

    [HttpPost]
    public async Task<ActionResult> CreateReservation(ModifyReservationDto reservationDto)
    {
        var reservationId = await _reservationService.CreateReservation(reservationDto);
        return Ok(new { CreatedReservationId = reservationId });
    }

    [HttpGet("customer/{customerId:int}")]
    public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservationsByCustomer(int customerId)
    {
        return Ok(await _reservationService.GetReservationsByCustomer(customerId));
    }

    [HttpGet("{reservationId:int}/menu-items")]
    public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetOrderedMenuItems(int reservationId)
    {
        return Ok(await _menuItemService.ListOrderedMenuItems(reservationId));
    }

    [HttpGet("{reservationId:int}/orders")]
    public async Task<ActionResult<IEnumerable<OrdersAndMenuItems>>> GetOrdersAndMenuItems(int reservationId)
    {
        return Ok(await _orderService.ListOrdersAndMenuItems(reservationId));
    }
}