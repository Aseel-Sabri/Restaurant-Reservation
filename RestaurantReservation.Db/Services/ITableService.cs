using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.Db.Services;

public interface ITableService
{
    Task<int> CreateTable(CreateTableDto tableDto);
    Task<TableDto> UpdateTable(int tableId, UpdateTableDto tableDto);
    Task DeleteTable(int tableId);
    Task<IEnumerable<TableDto>> GetAllTables();
    Task<TableDto> FindTableById(int tableId);
}