using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers;

[Authorize]
[ApiController]
[Route("/api/orders/{orderId:int}/order-items")]
public class OrderItemController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderItemController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    /// Gets a list of all order items within an order.
    /// </summary>
    /// <param name="orderId">The ID of the order.</param>
    /// <returns>A list of order item DTOs.</returns>
    /// <response code="200">Returns a list of order items within the order.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderItemDto>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetOrderItems(int orderId)
    {
        return Ok(await _orderService.GetOrderItems(orderId));
    }

    /// <summary>
    /// Gets an order item by ID within an order.
    /// </summary>
    /// <param name="orderId">The ID of the order.</param>
    /// <param name="orderItemId">The ID of the order item.</param>
    /// <returns>The order item DTO.</returns>
    /// <response code="200">Returns the requested order item within the order.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderItemDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet("{orderItemId:int}")]
    public async Task<ActionResult<OrderItemDto>> GetOrderItem(int orderId, int orderItemId)
    {
        return Ok(await _orderService.FindOrderItemById(orderId, orderItemId));
    }

    /// <summary>
    /// Deletes an order item by ID within an order.
    /// </summary>
    /// <param name="orderId">The ID of the order.</param>
    /// <param name="orderItemId">The ID of the order item to delete.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">No content if the deletion is successful.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpDelete("{orderItemId:int}")]
    public async Task<ActionResult> DeleteOrderItem(int orderId, int orderItemId)
    {
        await _orderService.DeleteOrderItem(orderId, orderItemId);
        return NoContent();
    }


    /// <summary>
    /// Updates an order item by ID within an order.
    /// </summary>
    /// <param name="orderId">The ID of the order.</param>
    /// <param name="orderItemId">The ID of the order item to update.</param>
    /// <param name="orderItemDto">The updated order item DTO.</param>
    /// <returns>The updated order item DTO.</returns>
    /// <response code="200">Returns the updated order item.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderItemDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPut("{orderItemId:int}")]
    public async Task<ActionResult<OrderItemDto>> UpdateOrderItem(int orderId, int orderItemId,
        UpdateOrderItemDto orderItemDto)
    {
        return Ok(await _orderService.UpdateOrderItem(orderId, orderItemId, orderItemDto));
    }

    /// <summary>
    /// Creates a new order item within an order.
    /// </summary>
    /// <param name="orderId">The ID of the order.</param>
    /// <param name="orderItemDto">The order item DTO for creation.</param>
    /// <returns>The ID of the created order item.</returns>
    /// <response code="200">Returns the ID of the created order item.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost]
    public async Task<ActionResult> CreateOrderItem(int orderId, CreateOrderItemDto orderItemDto)
    {
        var orderItemId = await _orderService.CreateOrderItem(orderId, orderItemDto);
        return Ok(new { CreatedOrderItemId = orderItemId });
    }
}