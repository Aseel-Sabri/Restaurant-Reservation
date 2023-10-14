using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public interface ITableRepository
{
    int CreateTable(Table table);
    Table UpdateTable(Table table);
    bool DeleteTable(int tableId);
    Table? FindTableById(int tableId);
    bool HasTableById(int tableId);
}