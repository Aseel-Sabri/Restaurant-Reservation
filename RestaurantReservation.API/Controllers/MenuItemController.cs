using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("/api/menu-items")]
public class MenuItemController : ControllerBase
{
    private readonly IMenuItemService _menuItemService;

    public MenuItemController(IMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMenuItems()
    {
        return Ok(await _menuItemService.GetAllItems());
    }

    [HttpGet("{menuItemId}")]
    public async Task<ActionResult<MenuItemDto>> GetMenuItem(int menuItemId)
    {
        return Ok(await _menuItemService.FindItemById(menuItemId));
    }

    [HttpDelete("{menuItemId}")]
    public async Task<ActionResult> DeleteMenuItem(int menuItemId)
    {
        await _menuItemService.DeleteItem(menuItemId);
        return NoContent();
    }

    [HttpPut("{menuItemId}")]
    public async Task<ActionResult<MenuItemDto>> UpdateMenuItem(int menuItemId, UpdateMenuItemDto menuItemDto)
    {
        return Ok(await _menuItemService.UpdateItem(menuItemId, menuItemDto));
    }


    [HttpPost]
    public async Task<ActionResult> CreateMenuItem(CreateMenuItemDto menuItemDto)
    {
        var itemId = await _menuItemService.CreateItem(menuItemDto);
        return Ok(new { CreatedMenuItemId = itemId });
    }
}