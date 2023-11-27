using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.DbContext;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly RestaurantReservationDbContext _dbContext;

    public OrderRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateOrder(Order order)
    {
        await _dbContext.Orders.AddAsync(order);
        await _dbContext.SaveChangesAsync();
        return order.OrderId;
    }

    public async Task<Order> UpdateOrder(Order order)
    {
        _dbContext.Entry(order).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return await FindOrderById(order.OrderId);
    }

    public async Task<bool> DeleteOrder(int orderId)
    {
        var order = await _dbContext.Orders.FindAsync(orderId);
        _dbContext.Orders.Remove(order);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    // TODO
    public async Task<List<OrdersAndMenuItemsDto>> ListOrdersAndMenuItems(int reservationId)
    {
        return await _dbContext.Orders
            .Where(order => order.ReservationId == reservationId)
            .Select(order =>
                new OrdersAndMenuItemsDto()
                {
                    EmployeeId = order.EmployeeId,
                    OrderDate = order.OrderDate,
                    OrderId = order.OrderId,
                    TotalAmount = order.TotalAmount,
                    MenuItems = order.OrderItems.Select(orderItem =>
                            new MenuItemDto()
                            {
                                ItemId = orderItem.Item.ItemId,
                                Description = orderItem.Item.Description,
                                Name = orderItem.Item.Name,
                                Price = orderItem.Item.Price,
                                RestaurantId = orderItem.Item.RestaurantId
                            })
                        .Distinct()
                        .ToList()
                })
            .AsSplitQuery()
            .ToListAsync();
    }

    public async Task<Order?> FindOrderById(int orderId)
    {
        return await _dbContext.Orders.FindAsync(orderId);
    }

    public async Task<bool> HasOrderById(int orderId)
    {
        return await FindOrderById(orderId) is not null;
    }

    public async Task<int> CreateOrderItem(OrderItem orderItem)
    {
        await _dbContext.OrderItems.AddAsync(orderItem);
        await _dbContext.SaveChangesAsync();
        return orderItem.OrderItemId;
    }

    public async Task<OrderItem> UpdateOrderItem(OrderItem orderItem)
    {
        _dbContext.Entry(orderItem).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return await FindOrderItemById(orderItem.OrderItemId);
    }

    public async Task<bool> DeleteOrderItem(int orderItemId)
    {
        var orderItem = await _dbContext.OrderItems.FindAsync(orderItemId);
        _dbContext.OrderItems.Remove(orderItem);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<List<OrderItem>> FindOrderItemsByMenuItem(int menuItemId)
    {
        return await _dbContext.OrderItems.Where(orderItem => orderItem.MenuItemId == menuItemId).ToListAsync();
    }

    public async Task<OrderItem?> FindOrderItemById(int orderItemId)
    {
        return await _dbContext.OrderItems.FindAsync(orderItemId);
    }

    public async Task<bool> HasOrderItemById(int orderItemId)
    {
        return await FindOrderItemById(orderItemId) is not null;
    }
}