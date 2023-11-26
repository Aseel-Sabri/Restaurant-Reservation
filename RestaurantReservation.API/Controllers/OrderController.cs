using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers;

[Authorize]
[ApiController]
[Route("/api/orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    /// Gets a list of all orders.
    /// </summary>
    /// <returns>A list of order DTOs.</returns>
    /// <response code="200">Returns a list of orders.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderDto>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
    {
        return Ok(await _orderService.GetAllOrders());
    }

    /// <summary>
    /// Gets an order by ID.
    /// </summary>
    /// <param name="orderId">The ID of the order.</param>
    /// <returns>The order DTO.</returns>
    /// <response code="200">Returns the requested order.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet("{orderId:int}")]
    public async Task<ActionResult<OrderDto>> GetOrder(int orderId)
    {
        return Ok(await _orderService.FindOrderById(orderId));
    }

    /// <summary>
    /// Deletes an order by ID.
    /// </summary>
    /// <param name="orderId">The ID of the order to delete.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">No content if the deletion is successful.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpDelete("{orderId:int}")]
    public async Task<ActionResult> DeleteOrder(int orderId)
    {
        await _orderService.DeleteOrder(orderId);
        return NoContent();
    }

    /// <summary>
    /// Updates an order by ID.
    /// </summary>
    /// <param name="orderId">The ID of the order to update.</param>
    /// <param name="orderDto">The updated order DTO.</param>
    /// <returns>The updated order DTO.</returns>
    /// <response code="200">Returns the updated order.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPut("{orderId:int}")]
    public async Task<ActionResult<OrderDto>> UpdateOrder(int orderId, ModifyOrderDto orderDto)
    {
        return Ok(await _orderService.UpdateOrder(orderId, orderDto));
    }

    /// <summary>
    /// Creates a new order.
    /// </summary>
    /// <param name="orderDto">The order DTO for creation.</param>
    /// <returns>The ID of the created order.</returns>
    /// <response code="200">Returns the ID of the created order.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost]
    public async Task<ActionResult> CreateOrder(ModifyOrderDto orderDto)
    {
        var orderId = await _orderService.CreateOrder(orderDto);
        return Ok(new { CreatedOrderId = orderId });
    }
}