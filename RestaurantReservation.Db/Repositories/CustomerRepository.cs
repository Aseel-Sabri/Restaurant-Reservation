using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.DbContext;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly RestaurantReservationDbContext _dbContext;

    public CustomerRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateCustomer(Customer customer)
    {
        await _dbContext.Customers.AddAsync(customer);
        await _dbContext.SaveChangesAsync();
        return customer.CustomerId;
    }

    public async Task<Customer> UpdateCustomer(Customer customer)
    {
        _dbContext.Entry(customer).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return await FindCustomerById(customer.CustomerId);
    }

    public async Task<bool> DeleteCustomer(int customerId)
    {
        var customer = await FindCustomerById(customerId);
        _dbContext.Customers.Remove(customer);

        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<Customer?> FindCustomerById(int customerId)
    {
        return await _dbContext.Customers.FindAsync(customerId);
    }

    public async Task<List<Customer>> FindCustomersWithPartySizeGreaterThan(int partySize)
    {
        var customers =
            _dbContext.Customers.FromSqlInterpolated($"EXEC sp_FindCustomersWithPartySizeGreaterThan {partySize}");
        return await customers.ToListAsync();
    }

    public async Task<bool> HasCustomerById(int customerId)
    {
        return await FindCustomerById(customerId) is not null;
    }
}