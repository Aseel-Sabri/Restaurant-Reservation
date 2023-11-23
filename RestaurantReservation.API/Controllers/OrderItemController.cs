using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("/api/orders/{orderId:int}/order-items")]
public class OrderItemController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderItemController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetOrderItems(int orderId)
    {
        return Ok(await _orderService.GetOrderItems(orderId));
    }

    [HttpGet("{orderItemId:int}")]
    public async Task<ActionResult<OrderItemDto>> GetOrderItem(int orderId, int orderItemId)
    {
        return Ok(await _orderService.FindOrderItemById(orderId, orderItemId));
    }

    [HttpDelete("{orderItemId:int}")]
    public async Task<ActionResult> DeleteOrderItem(int orderId, int orderItemId)
    {
        await _orderService.DeleteOrderItem(orderId, orderItemId);
        return NoContent();
    }

    [HttpPut("{orderItemId:int}")]
    public async Task<ActionResult<ReservationDto>> UpdateOrderItem(int orderId, int orderItemId,
        UpdateOrderItemDto orderItemDto)
    {
        return Ok(await _orderService.UpdateOrderItem(orderId, orderItemId, orderItemDto));
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrderItem(int orderId, CreateOrderItemDto orderItemDto)
    {
        var orderItemId = await _orderService.CreateOrderItem(orderId, orderItemDto);
        return Ok(new { CreatedOrderItemId = orderItemId });
    }
}