using FluentResults;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.Db.Services;

public interface ITableService
{
    Task<Result<int>> CreateTable(TableDto tableDto);
    Task<Result<TableDto>> UpdateTableCapacity(int tableId, int capacity);
    Task<Result> DeleteTable(int tableId);
}