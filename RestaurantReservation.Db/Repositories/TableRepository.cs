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

    public async Task<int> CreateTable(Table table)
    {
        await _dbContext.Tables.AddAsync(table);
        await _dbContext.SaveChangesAsync();
        return table.TableId;
    }

    public async Task<Table> UpdateTable(Table table)
    {
        _dbContext.Entry(table).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return await FindTableById(table.TableId);
    }

    public async Task<bool> DeleteTable(int tableId)
    {
        var table = await _dbContext.Tables.FindAsync(tableId);
        _dbContext.Tables.Remove(table);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<Table?> FindTableById(int tableId)
    {
        return await _dbContext.Tables.FindAsync(tableId);
    }

    public async Task<bool> HasTableById(int tableId)
    {
        return await FindTableById(tableId) is not null;
    }

    public async Task<List<Table>> GetAllTables()
    {
        return await _dbContext.Tables.ToListAsync();
    }
}