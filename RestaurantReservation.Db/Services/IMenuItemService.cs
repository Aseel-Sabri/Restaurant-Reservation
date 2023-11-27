using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.Db.Services;

public interface IMenuItemService
{
    Task<int> CreateItem(CreateMenuItemDto menuItemDto);
    Task<MenuItemDto> UpdateItem(int menuItemId, UpdateMenuItemDto menuItemDto);
    Task DeleteItem(int menuItemId);
    Task<IEnumerable<MenuItemDto>> GetAllItems();
    Task<MenuItemDto> FindItemById(int menuItemId);
    Task<IEnumerable<MenuItemDto>> ListOrderedMenuItems(int reservationId);
}