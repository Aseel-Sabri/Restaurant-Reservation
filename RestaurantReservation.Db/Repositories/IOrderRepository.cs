using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public interface IOrderRepository
{
    Task<int> CreateOrder(Order order);
    Task<Order> UpdateOrder(Order order);
    Task<bool> DeleteOrder(int orderId);
    Task<int> CreateOrderItem(OrderItem orderItem);
    Task<OrderItem> UpdateOrderItem(OrderItem orderItem);
    Task<bool> DeleteOrderItem(int orderItemId);
    Task<Order?> FindOrderById(int orderId);
    Task<bool> HasOrderById(int orderId);
    Task<OrderItem?> FindOrderItemById(int orderItemId);
    Task<bool> HasOrderItemById(int orderItemId);
    Task<List<OrderItem>> FindOrderItemsByMenuItem(int menuItemId);
    Task<List<OrdersAndMenuItemsDto>> ListOrdersAndMenuItems(int reservationId);
}