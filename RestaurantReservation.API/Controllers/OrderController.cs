using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("/api/orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
    {
        return Ok(await _orderService.GetAllOrders());
    }

    [HttpGet("{orderId:int}")]
    public async Task<ActionResult<OrderDto>> GetOrder(int orderId)
    {
        return Ok(await _orderService.FindOrderById(orderId));
    }

    [HttpDelete("{orderId:int}")]
    public async Task<ActionResult> DeleteOrder(int orderId)
    {
        await _orderService.DeleteOrder(orderId);
        return NoContent();
    }

    [HttpPut("{orderId:int}")]
    public async Task<ActionResult<ReservationDto>> UpdateOrder(int orderId, ModifyOrderDto orderDto)
    {
        return Ok(await _orderService.UpdateOrder(orderId, orderDto));
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrder(ModifyOrderDto orderDto)
    {
        var orderId = await _orderService.CreateOrder(orderDto);
        return Ok(new { CreatedOrderId = orderId });
    }
}