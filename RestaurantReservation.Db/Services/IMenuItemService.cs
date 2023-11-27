using FluentResults;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.Db.Services;

public interface IMenuItemService
{
    Task<Result<int>> CreateItem(MenuItemDto menuItemDto);
    Task<Result<MenuItemDto>> UpdateItem(MenuItemDto menuItemDto);
    Task<Result> DeleteItem(int menuItemId);
    Task<Result<List<MenuItemDto>>> ListOrderedMenuItems(int reservationId);
}