using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public interface IMenuItemRepository
{
    Task<int> CreateItem(MenuItem item);
    Task<MenuItem> UpdateItem(MenuItem item);
    Task<bool> DeleteItem(int itemId);
    Task<MenuItem?> FindItemById(int itemId);
    Task<bool> HasItemById(int itemId);
    Task<List<MenuItem>> ListOrderedMenuItems(int reservationId);
    Task<List<MenuItem>> GetAllMenuItems();
}