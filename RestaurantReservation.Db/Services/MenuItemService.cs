using AutoMapper;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Exceptions;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services;

public class MenuItemService : IMenuItemService
{
    private readonly IMenuItemRepository _menuItemRepository;
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IMapper _mapper;

    public MenuItemService(IMenuItemRepository menuItemRepository, IRestaurantRepository restaurantRepository,
        IMapper mapper)
    {
        _menuItemRepository = menuItemRepository;
        _restaurantRepository = restaurantRepository;
        _mapper = mapper;
    }

    public async Task<int> CreateItem(CreateMenuItemDto menuItemDto)
    {
        if (!await _restaurantRepository.HasRestaurantById((int)menuItemDto.RestaurantId!))
            throw new NotFoundException($"No Restaurant With ID {menuItemDto.RestaurantId} Exists");

        var menuItem = _mapper.Map<MenuItem>(menuItemDto);

        var itemId = await _menuItemRepository.CreateItem(menuItem);
        return itemId;
    }


    public async Task<MenuItemDto> UpdateItem(int menuItemId, UpdateMenuItemDto menuItemDto)
    {
        var menuItem = await _menuItemRepository.FindItemById(menuItemId);
        if (menuItem is null)
            throw new NotFoundException($"No Menu Item With ID {menuItemId} Exists");

        _mapper.Map(menuItemDto, menuItem);

        var updatedMenuItem = await _menuItemRepository.UpdateItem(menuItem);
        return _mapper.Map<MenuItemDto>(updatedMenuItem);
    }

    public async Task DeleteItem(int menuItemId)
    {
        if (!await _menuItemRepository.HasItemById(menuItemId))
            throw new NotFoundException($"No MenuItem With ID {menuItemId} Exists");

        try
        {
            if (!await _menuItemRepository.DeleteItem(menuItemId))
                throw new ApiException($"Could Not Delete MenuItem With ID {menuItemId}");
        }
        catch (Exception e)
        {
            throw new ApiException($"Could Not Delete MenuItem With ID {menuItemId}, It May Have Related Data", e);
        }
    }

    public async Task<IEnumerable<MenuItemDto>> GetAllItems()
    {
        var items = await _menuItemRepository.GetAllMenuItems();
        return _mapper.Map<IEnumerable<MenuItemDto>>(items);
    }

    public async Task<MenuItemDto> FindItemById(int menuItemId)
    {
        var item = await _menuItemRepository.FindItemById(menuItemId);
        if (item is null)
            throw new NotFoundException($"No Menu Item With ID {menuItemId} Exists");

        return _mapper.Map<MenuItemDto>(item);
    }
}