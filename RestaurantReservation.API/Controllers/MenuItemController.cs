using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers;

[Authorize]
[ApiController]
[Route("/api/menu-items")]
public class MenuItemController : ControllerBase
{
    private readonly IMenuItemService _menuItemService;

    public MenuItemController(IMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }

    /// <summary>
    /// Gets a list of all menu items.
    /// </summary>
    /// <returns>A list of menu item DTOs.</returns>
    /// <response code="200">Returns a list of menu items.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MenuItemDto>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMenuItems()
    {
        return Ok(await _menuItemService.GetAllItems());
    }

    /// <summary>
    /// Gets a menu item by ID.
    /// </summary>
    /// <param name="menuItemId">The ID of the menu item.</param>
    /// <returns>The menu item DTO.</returns>
    /// <response code="200">Returns the requested menu item.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MenuItemDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet("{menuItemId:int}")]
    public async Task<ActionResult<MenuItemDto>> GetMenuItem(int menuItemId)
    {
        return Ok(await _menuItemService.FindItemById(menuItemId));
    }

    /// <summary>
    /// Deletes a menu item by ID.
    /// </summary>
    /// <param name="menuItemId">The ID of the menu item to delete.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">No content if the deletion is successful.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpDelete("{menuItemId:int}")]
    public async Task<ActionResult> DeleteMenuItem(int menuItemId)
    {
        await _menuItemService.DeleteItem(menuItemId);
        return NoContent();
    }

    /// <summary>
    /// Updates a menu item by ID.
    /// </summary>
    /// <param name="menuItemId">The ID of the menu item to update.</param>
    /// <param name="menuItemDto">The updated menu item DTO.</param>
    /// <returns>The updated menu item DTO.</returns>
    /// <response code="200">Returns the updated menu item.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MenuItemDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPut("{menuItemId:int}")]
    public async Task<ActionResult<MenuItemDto>> UpdateMenuItem(int menuItemId, UpdateMenuItemDto menuItemDto)
    {
        return Ok(await _menuItemService.UpdateItem(menuItemId, menuItemDto));
    }

    /// <summary>
    /// Creates a new menu item.
    /// </summary>
    /// <param name="menuItemDto">The menu item DTO for creation.</param>
    /// <returns>The ID of the created menu item.</returns>
    /// <response code="200">Returns the ID of the created menu item.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost]
    public async Task<ActionResult> CreateMenuItem(CreateMenuItemDto menuItemDto)
    {
        var itemId = await _menuItemService.CreateItem(menuItemDto);
        return Ok(new { CreatedMenuItemId = itemId });
    }
}