using FluentResults;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.Db.Services;

public interface IMenuItemService
{
    Result<int> CreateItem(MenuItemDto menuItemDto);
    Result<MenuItemDto> UpdateItem(MenuItemDto menuItemDto);
    Result DeleteItem(int menuItemId);
    Result<List<MenuItemDto>> ListOrderedMenuItems(int reservationId);
}