using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public interface ITableRepository
{
    Task<int> CreateTable(Table table);
    Task<Table> UpdateTable(Table table);
    Task<bool> DeleteTable(int tableId);
    Task<Table?> FindTableById(int tableId);
    Task<bool> HasTableById(int tableId);
}