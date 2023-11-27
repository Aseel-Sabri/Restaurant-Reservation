using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.ValueObjects;

namespace RestaurantReservation.Db.Services;

public interface IOrderService
{
    Task<int> CreateOrder(ModifyOrderDto orderDto);
    Task<OrderDto> UpdateOrder(int orderId, ModifyOrderDto orderDto);
    Task DeleteOrder(int orderId);
    Task<List<OrdersAndMenuItems>> ListOrdersAndMenuItems(int reservationId);
    Task<int> CreateOrderItem(int orderId, CreateOrderItemDto orderItemDto);
    Task<OrderItemDto> UpdateOrderItem(int orderId, int orderItemId, UpdateOrderItemDto orderItemDto);
    Task DeleteOrderItem(int orderId, int orderItemId);
    Task<IEnumerable<OrderDto>> GetAllOrders();
    Task<IEnumerable<OrderItemDto>> GetOrderItems(int orderId);
    Task<OrderDto> FindOrderById(int orderId);
    Task<OrderItemDto> FindOrderItemById(int orderId, int orderItemId);
}