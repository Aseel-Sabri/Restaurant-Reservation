using FluentResults;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.Db.Services;

public interface ITableService
{
    Result<int> CreateTable(TableDto tableDto);
    Result<TableDto> UpdateTableCapacity(int tableId, int capacity);
    Result DeleteTable(int tableId);
}