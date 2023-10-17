using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.DbContext;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class TableRepository : ITableRepository
{
    private readonly RestaurantReservationDbContext _dbContext;

    public TableRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int CreateTable(Table table)
    {
        _dbContext.Tables.Add(table);
        _dbContext.SaveChanges();
        return table.TableId;
    }

    public Table UpdateTable(Table table)
    {
        _dbContext.Entry(table).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return FindTableById(table.TableId);
    }

    public bool DeleteTable(int tableId)
    {
        var table = _dbContext.Tables.Find(tableId);
        _dbContext.Tables.Remove(table);
        return _dbContext.SaveChanges() > 0;
    }

    public Table? FindTableById(int tableId)
    {
        return _dbContext.Tables.Find(tableId);
    }

    public bool HasTableById(int tableId)
    {
        return FindTableById(tableId) is not null;
    }
}