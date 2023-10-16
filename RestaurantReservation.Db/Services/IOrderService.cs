using FluentResults;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.Db.Services;

public interface IOrderService
{
    Result<int> CreateOrder(OrderDto orderDto);
    Result<OrderDto> UpdateOrder(OrderDto orderDto);
    Result DeleteOrder(int orderId);
    Result<int> CreateOrderItem(OrderItemDto orderItemDto);
    Result<OrderItemDto> UpdateOrderItemQuantity(int orderItemId, int quantity);
    Result DeleteOrderItem(int orderItemId);
    Result<List<OrdersAndMenuItemsDto>> ListOrdersAndMenuItems(int reservationId);
}