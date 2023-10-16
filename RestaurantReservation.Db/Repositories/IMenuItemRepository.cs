using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public interface IMenuItemRepository
{
    int CreateItem(MenuItem item);
    MenuItem UpdateItem(MenuItem item);
    bool DeleteItem(int itemId);
    MenuItem? FindItemById(int itemId);
    bool HasItemById(int itemId);
}