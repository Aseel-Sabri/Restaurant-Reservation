using FluentResults;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.Db.Services;

public interface ICustomerService
{
    Result<int> CreateCustomer(CustomerDto customerDto);
    Result<CustomerDto> UpdateCustomer(CustomerDto customerDto);
    Result DeleteCustomer(int customerId);
}