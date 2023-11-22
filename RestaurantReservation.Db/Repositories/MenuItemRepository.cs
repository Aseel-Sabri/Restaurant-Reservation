using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.DbContext;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly RestaurantReservationDbContext _dbContext;

    public MenuItemRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateItem(MenuItem item)
    {
        await _dbContext.MenuItems.AddAsync(item);
        await _dbContext.SaveChangesAsync();
        return item.ItemId;
    }

    public async Task<MenuItem> UpdateItem(MenuItem item)
    {
        _dbContext.Entry(item).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return await FindItemById(item.ItemId);
    }

    public async Task<bool> DeleteItem(int itemId)
    {
        var item = await _dbContext.MenuItems.FindAsync(itemId);
        _dbContext.MenuItems.Remove(item);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<List<MenuItem>> ListOrderedMenuItems(int reservationId)
    {
        var menuItems = _dbContext.OrderItems
            .Where(orderItem => orderItem.Order.ReservationId == reservationId)
            .Select(orderItem =>
                new MenuItem()
                {
                    Description = orderItem.Item.Description,
                    Name = orderItem.Item.Name,
                    ItemId = orderItem.Item.ItemId,
                    Price = orderItem.Item.Price,
                    RestaurantId = orderItem.Item.RestaurantId
                }
            )
            .Distinct();


        return await menuItems.ToListAsync();
    }

    public async Task<List<MenuItem>> GetAllMenuItems()
    {
        return await _dbContext.MenuItems.ToListAsync();
    }

    public async Task<MenuItem?> FindItemById(int itemId)
    {
        return await _dbContext.MenuItems.FindAsync(itemId);
    }

    public async Task<bool> HasItemById(int itemId)
    {
        return await FindItemById(itemId) is not null;
    }
}