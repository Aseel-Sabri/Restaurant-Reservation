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

    public int CreateCustomer(Customer customer)
    {
        _dbContext.Customers.Add(customer);
        _dbContext.SaveChanges();
        return customer.CustomerId;
    }

    public Customer UpdateCustomer(Customer customer)
    {
        _dbContext.Entry(customer).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return FindCustomerById(customer.CustomerId);
    }

    public bool DeleteCustomer(int customerId)
    {
        var customer = FindCustomerById(customerId);
        _dbContext.Customers.Remove(customer);

        return _dbContext.SaveChanges() > 0;
    }

    public Customer? FindCustomerById(int customerId)
    {
        return _dbContext.Customers.Find(customerId);
    }

    public List<Customer> FindCustomersWithPartySizeGreaterThan(int partySize)
    {
        var customers =
            _dbContext.Customers.FromSqlInterpolated($"EXEC sp_FindCustomersWithPartySizeGreaterThan {partySize}");
        return customers.ToList();
    }

    public bool HasCustomerById(int customerId)
    {
        return FindCustomerById(customerId) is not null;
    }
}