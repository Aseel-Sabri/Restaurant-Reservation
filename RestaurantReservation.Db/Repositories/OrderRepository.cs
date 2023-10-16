using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly RestaurantReservationDbContext _dbContext;

    public OrderRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int CreateOrder(Order order)
    {
        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();
        return order.OrderId;
    }

    public Order UpdateOrder(Order order)
    {
        _dbContext.Entry(order).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return FindOrderById(order.OrderId);
    }

    public bool DeleteOrder(int orderId)
    {
        var order = _dbContext.Orders.Find(orderId);
        _dbContext.Orders.Remove(order);
        return _dbContext.SaveChanges() > 0;
    }

    public Order? FindOrderById(int orderId)
    {
        return _dbContext.Orders.Find(orderId);
    }

    public bool HasOrderById(int orderId)
    {
        return FindOrderById(orderId) is not null;
    }

    public int CreateOrderItem(OrderItem orderItem)
    {
        _dbContext.OrderItems.Add(orderItem);
        _dbContext.SaveChanges();
        return orderItem.OrderItemId;
    }

    public OrderItem UpdateOrderItem(OrderItem orderItem)
    {
        _dbContext.Entry(orderItem).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return FindOrderItemById(orderItem.OrderItemId);
    }

    public bool DeleteOrderItem(int orderItemId)
    {
        var orderItem = _dbContext.OrderItems.Find(orderItemId);
        _dbContext.OrderItems.Remove(orderItem);
        return _dbContext.SaveChanges() > 0;
    }

    public List<OrderItem> GetOrderItemsOfMenuItem(int menuItemId)
    {
        return _dbContext.OrderItems.Where(orderItem => orderItem.MenuItemId == menuItemId).ToList();
    }

    public OrderItem? FindOrderItemById(int orderItemId)
    {
        return _dbContext.OrderItems.Find(orderItemId);
    }

    public bool HasOrderItemById(int orderItemId)
    {
        return FindOrderById(orderItemId) is not null;
    }
}