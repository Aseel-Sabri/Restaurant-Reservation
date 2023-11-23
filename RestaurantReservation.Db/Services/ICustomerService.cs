using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.Db.Services;

public interface ICustomerService
{
    Task<int> CreateCustomer(ModifyCustomerDto customerDto);
    Task<CustomerDto> UpdateCustomer(int customerId, ModifyCustomerDto customerDto);
    Task DeleteCustomer(int customerId);
    Task<IEnumerable<CustomerDto>> FindCustomersWithPartySizeGreaterThan(int partySize);
    Task<IEnumerable<CustomerDto>> GetAllCustomers();
    Task<CustomerDto> FindCustomerById(int customerId);
}