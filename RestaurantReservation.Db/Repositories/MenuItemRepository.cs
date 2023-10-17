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

    public int CreateItem(MenuItem item)
    {
        _dbContext.MenuItems.Add(item);
        _dbContext.SaveChanges();
        return item.ItemId;
    }

    public MenuItem UpdateItem(MenuItem item)
    {
        _dbContext.Entry(item).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return FindItemById(item.ItemId);
    }

    public bool DeleteItem(int itemId)
    {
        var item = _dbContext.MenuItems.Find(itemId);
        _dbContext.MenuItems.Remove(item);
        return _dbContext.SaveChanges() > 0;
    }

    public List<MenuItem> ListOrderedMenuItems(int reservationId)
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


        return menuItems.ToList();
    }

    public MenuItem? FindItemById(int itemId)
    {
        return _dbContext.MenuItems.Find(itemId);
    }

    public bool HasItemById(int itemId)
    {
        return FindItemById(itemId) is not null;
    }
}