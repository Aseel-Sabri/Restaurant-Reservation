using FluentResults;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services;

public class TableService : ITableService
{
    private readonly ITableRepository _tableRepository;
    private readonly IRestaurantRepository _restaurantRepository;

    public TableService(ITableRepository tableRepository, IRestaurantRepository restaurantRepository)
    {
        _tableRepository = tableRepository;
        _restaurantRepository = restaurantRepository;
    }

    public Result<int> CreateTable(TableDto tableDto)
    {
        if (tableDto.HasAnyNullOrEmptyFields())
        {
            return Result.Fail($"All Table Fields Must Be Provided");
        }

        if (!_restaurantRepository.HasRestaurantById((int)tableDto.RestaurantId!))
        {
            return Result.Fail($"No Restaurant With ID {tableDto.RestaurantId} Exists");
        }

        var table = new Table()
        {
            RestaurantId = (int)tableDto.RestaurantId,
            Capacity = (int)tableDto.Capacity!
        };
        var tableId = _tableRepository.CreateTable(table);
        return Result.Ok(tableId);
    }

    public Result<TableDto> UpdateTableCapacity(int tableId, int capacity)
    {
        var table = _tableRepository.FindTableById(tableId);
        if (table is null)
            return Result.Fail($"No Table with ID {tableId} Exists");

        table.Capacity = capacity;

        var updatedTable = _tableRepository.UpdateTable(table);
        return Result.Ok(MapToTableDto(updatedTable));
    }

    public Result DeleteTable(int tableId)
    {
        if (!_tableRepository.HasTableById(tableId))
            return Result.Fail($"No Table With ID {tableId} Exists");

        try
        {
            return Result.OkIf(_tableRepository.DeleteTable(tableId),
                $"Could Not Delete Table With ID {tableId}");
        }
        catch (Exception e)
        {
            return Result.Fail(
                $"Could Not Delete Table With ID {tableId}, It May Have Related Data");
        }
    }

    private TableDto MapToTableDto(Table table)
    {
        return new TableDto()
        {
            TableId = table.TableId,
            RestaurantId = table.RestaurantId,
            Capacity = table.Capacity
        };
    }
}