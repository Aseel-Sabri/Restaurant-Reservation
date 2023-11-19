using FluentResults;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services;

public class MenuItemService : IMenuItemService
{
    private readonly IMenuItemRepository _menuItemRepository;
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IReservationRepository _reservationRepository;

    public MenuItemService(IMenuItemRepository menuItemRepository, IRestaurantRepository restaurantRepository,
        IReservationRepository reservationRepository)
    {
        _menuItemRepository = menuItemRepository;
        _restaurantRepository = restaurantRepository;
        _reservationRepository = reservationRepository;
    }

    public async Task<Result<int>> CreateItem(MenuItemDto menuItemDto)
    {
        if (menuItemDto.HasAnyNullOrEmptyFields())
            return Result.Fail($"All MenuItem Fields Must Be Provided");

        if (!await _restaurantRepository.HasRestaurantById((int)menuItemDto.RestaurantId!))
            return Result.Fail($"No Restaurant With ID {menuItemDto.RestaurantId} Exists");


        var menuItem = new MenuItem()
        {
            Name = menuItemDto.Name!,
            Description = menuItemDto.Description!,
            Price = (int)menuItemDto.Price!,
            RestaurantId = (int)menuItemDto.RestaurantId!
        };

        var itemId = await _menuItemRepository.CreateItem(menuItem);
        return Result.Ok(itemId);
    }


    public async Task<Result<MenuItemDto>> UpdateItem(MenuItemDto menuItemDto)
    {
        var menuItem = await _menuItemRepository.FindItemById(menuItemDto.ItemId);
        if (menuItem is null)
            return Result.Fail($"No Menu Item With ID {menuItemDto.ItemId} Exists");

        // TODO: Check for empty strings
        menuItem.Name = menuItemDto.Name ?? menuItem.Name;
        menuItem.Description = menuItemDto.Description ?? menuItem.Description;
        menuItem.RestaurantId = menuItemDto.RestaurantId ?? menuItem.RestaurantId;
        menuItem.Price = menuItemDto.Price ?? menuItem.Price;


        var updatedMenuItem = await _menuItemRepository.UpdateItem(menuItem);
        return Result.Ok(MapToMenuItemDto(updatedMenuItem));
    }

    public async Task<Result> DeleteItem(int menuItemId)
    {
        if (!await _menuItemRepository.HasItemById(menuItemId))
            return Result.Fail($"No MenuItem With ID {menuItemId} Exists");

        try
        {
            return Result.OkIf(await _menuItemRepository.DeleteItem(menuItemId),
                $"Could Not Delete MenuItem With ID {menuItemId}");
        }
        catch (Exception e)
        {
            return Result.Fail($"Could Not Delete MenuItem With ID {menuItemId}, It May Have Related Data");
        }
    }

    public async Task<Result<List<MenuItemDto>>> ListOrderedMenuItems(int reservationId)
    {
        if (!await _reservationRepository.HasReservationById(reservationId))
            return Result.Fail($"No Reservation With ID {reservationId} Exists");

        return (await _menuItemRepository.ListOrderedMenuItems(reservationId))
            .Select(MapToMenuItemDto)
            .ToList();
    }


    private MenuItemDto MapToMenuItemDto(MenuItem menuItem)
    {
        return new MenuItemDto()
        {
            ItemId = menuItem.ItemId,
            Name = menuItem.Name,
            Description = menuItem.Description,
            Price = menuItem.Price,
            RestaurantId = menuItem.RestaurantId
        };
    }
}