using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public interface IOrderRepository
{
    int CreateOrder(Order order);
    Order UpdateOrder(Order order);
    bool DeleteOrder(int orderId);
    int CreateOrderItem(OrderItem orderItem);
    OrderItem UpdateOrderItem(OrderItem orderItem);
    bool DeleteOrderItem(int orderItemId);
    Order? FindOrderById(int orderId);
    bool HasOrderById(int orderId);
    OrderItem? FindOrderItemById(int orderItemId);
    bool HasOrderItemById(int orderItemId);
    List<OrderItem> GetOrderItemsOfMenuItem(int menuItemId);
    List<OrdersAndMenuItemsDto> ListOrdersAndMenuItems(int reservationId);
}