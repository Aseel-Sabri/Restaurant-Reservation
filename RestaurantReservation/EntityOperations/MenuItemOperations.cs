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

    public void CreateItem()
    {
        var itemDto = new MenuItemDto()
        {
            RestaurantId = 1,
            Name = "ABC",
            Description = "XYZ",
            Price = 2.99
        };

        var result = _menuItemService.CreateItem(itemDto);
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

    public void UpdateItem()
    {
        var itemDto = new MenuItemDto()
        {
            ItemId = 1,
            Price = 5
        };

        var result = _menuItemService.UpdateItem(itemDto);
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

    public void DeleteItem(int itemId)
    {
        var result = _menuItemService.DeleteItem(itemId);

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
}