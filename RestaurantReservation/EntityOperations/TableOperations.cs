using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.EntityOperations;

public class TableOperations
{
    private readonly ITableService _tableService;

    public TableOperations(ITableService tableService)
    {
        _tableService = tableService;
    }

    public async Task CreateTable()
    {
        var tableDto = new TableDto()
        {
            Capacity = 4,
            RestaurantId = 1
        };

        var result = await _tableService.CreateTable(tableDto);
        if (result.IsSuccess)
        {
            var createdTableId = result.Value;
            Console.WriteLine($"Table Added With ID {createdTableId}");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public async Task UpdateTableCapacity()
    {
        var result = await _tableService.UpdateTableCapacity(1, 6);
        if (result.IsSuccess)
        {
            Console.WriteLine($"Updated Table: {Environment.NewLine}{result.Value}");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public async Task DeleteTable(int restaurantId)
    {
        var result = await _tableService.DeleteTable(restaurantId);

        if (result.IsSuccess)
        {
            Console.WriteLine($"Table With ID {restaurantId} Deleted Successfully");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }
}