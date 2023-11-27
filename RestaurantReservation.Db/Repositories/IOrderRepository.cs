using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.ValueObjects;

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
    Task<bool> HasOrderItemById(int orderId, int orderItemId);
    Task<List<OrderItem>> FindOrderItemsByMenuItem(int menuItemId);
    Task<List<OrdersAndMenuItems>> ListOrdersAndMenuItems(int reservationId);
    Task<List<Order>> GetAllOrders();
    Task<List<OrderItem>> GetOrderItems(int orderId);
    Task<double> GetOrderTotalAmount(int orderId);
}