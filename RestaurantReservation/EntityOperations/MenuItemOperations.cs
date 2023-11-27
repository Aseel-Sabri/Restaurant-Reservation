using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.EntityOperations;

public class MenuItemOperations
{
    private readonly IMenuItemService _menuItemService;

    public MenuItemOperations(IMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }

    public async Task CreateItem()
    {
        var itemDto = new MenuItemDto()
        {
            RestaurantId = 1,
            Name = "ABC",
            Description = "XYZ",
            Price = 2.99
        };

        var result = await _menuItemService.CreateItem(itemDto);
        if (result.IsSuccess)
        {
            var createdItemId = result.Value;
            Console.WriteLine($"Menu Item Added With ID {createdItemId}");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public async Task UpdateItem()
    {
        var itemDto = new MenuItemDto()
        {
            ItemId = 1,
            Price = 5
        };

        var result = await _menuItemService.UpdateItem(itemDto);
        if (result.IsSuccess)
        {
            Console.WriteLine($"Updated Menu Item: {Environment.NewLine}{result.Value}");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public async Task DeleteItem(int itemId)
    {
        var result = await _menuItemService.DeleteItem(itemId);

        if (result.IsSuccess)
        {
            Console.WriteLine($"Menu Item With ID {itemId} Deleted Successfully");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public async Task ListOrderedMenuItems(int reservationId)
    {
        var result = await _menuItemService.ListOrderedMenuItems(reservationId);

        if (result.IsFailed)
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
            Console.WriteLine();
            return;
        }

        var menuItems = result.Value;

        if (!menuItems.Any())
        {
            Console.WriteLine($"There is No Menu Items for reservation With ID {reservationId}");
            Console.WriteLine();
            return;
        }

        menuItems.ForEach(menuItem =>
        {
            Console.WriteLine(menuItem);
            Console.WriteLine();
        });
    }
}