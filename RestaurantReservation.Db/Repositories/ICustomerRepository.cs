using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public interface ICustomerRepository
{
    int CreateCustomer(Customer customer);
    Customer UpdateCustomer(Customer customer);
    bool DeleteCustomer(int customerId);
    Customer? FindCustomerById(int customerId);
    bool HasCustomerById(int customerId);
}