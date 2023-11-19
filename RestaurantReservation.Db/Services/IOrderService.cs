using FluentResults;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.Db.Services;

public interface IOrderService
{
    Task<Result<int>> CreateOrder(OrderDto orderDto);
    Task<Result<OrderDto>> UpdateOrder(OrderDto orderDto);
    Task<Result> DeleteOrder(int orderId);
    Task<Result<int>> CreateOrderItem(OrderItemDto orderItemDto);
    Task<Result<OrderItemDto>> UpdateOrderItemQuantity(int orderItemId, int quantity);
    Task<Result> DeleteOrderItem(int orderItemId);
    Task<Result<List<OrdersAndMenuItemsDto>>> ListOrdersAndMenuItems(int reservationId);
}