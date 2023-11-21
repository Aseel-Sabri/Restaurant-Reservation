using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public interface ICustomerRepository
{
    Task<int> CreateCustomer(Customer customer);
    Task<Customer> UpdateCustomer(Customer customer);
    Task<bool> DeleteCustomer(int customerId);
    Task<Customer?> FindCustomerById(int customerId);
    Task<bool> HasCustomerById(int customerId);
    Task<List<Customer>> FindCustomersWithPartySizeGreaterThan(int partySize);
    Task<List<Customer>> GetAllCustomers();
}