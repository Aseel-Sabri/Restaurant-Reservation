using FluentResults;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.Db.Services;

public interface ICustomerService
{
    Task<Result<int>> CreateCustomer(CustomerDto customerDto);
    Task<Result<CustomerDto>> UpdateCustomer(CustomerDto customerDto);
    Task<Result> DeleteCustomer(int customerId);
    Task<List<CustomerDto>> FindCustomersWithPartySizeGreaterThan(int partySize);
}