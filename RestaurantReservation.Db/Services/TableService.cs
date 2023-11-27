using AutoMapper;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Exceptions;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services;

public class TableService : ITableService
{
    private readonly ITableRepository _tableRepository;
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IMapper _mapper;

    public TableService(ITableRepository tableRepository, IRestaurantRepository restaurantRepository, IMapper mapper)
    {
        _tableRepository = tableRepository;
        _restaurantRepository = restaurantRepository;
        _mapper = mapper;
    }

    public async Task<int> CreateTable(CreateTableDto tableDto)
    {
        if (!await _restaurantRepository.HasRestaurantById((int)tableDto.RestaurantId!))
            throw new NotFoundException($"No Restaurant With ID {tableDto.RestaurantId} Exists");

        var table = _mapper.Map<Table>(tableDto);

        var tableId = await _tableRepository.CreateTable(table);
        return tableId;
    }

    public async Task<TableDto> UpdateTable(int tableId, UpdateTableDto tableDto)
    {
        var table = await _tableRepository.FindTableById(tableId);
        if (table is null)
            throw new NotFoundException($"No Table with ID {tableId} Exists");

        _mapper.Map(tableDto, table);

        var updatedTable = await _tableRepository.UpdateTable(table);
        return _mapper.Map<TableDto>(updatedTable);
    }

    public async Task DeleteTable(int tableId)
    {
        if (!await _tableRepository.HasTableById(tableId))
            throw new NotFoundException($"No Table With ID {tableId} Exists");

        try
        {
            if (!await _tableRepository.DeleteTable(tableId))
                throw new ApiException($"Could Not Delete Table With ID {tableId}");
        }
        catch (Exception e)
        {
            throw new ApiException(
                $"Could Not Delete Table With ID {tableId}, It May Have Related Data", e);
        }
    }

    public async Task<IEnumerable<TableDto>> GetAllTables()
    {
        var tables = await _tableRepository.GetAllTables();
        return _mapper.Map<IEnumerable<TableDto>>(tables);
    }

    public async Task<TableDto> FindTableById(int tableId)
    {
        var table = await _tableRepository.FindTableById(tableId);
        if (table is null)
            throw new NotFoundException($"No Table With ID {tableId} Exists");

        return _mapper.Map<TableDto>(table);
    }
}