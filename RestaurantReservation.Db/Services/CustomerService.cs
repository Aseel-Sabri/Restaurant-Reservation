using FluentResults;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Result<int> CreateCustomer(CustomerDto customerDto)
    {
        if (HasAnyNullOrEmptyFields(customerDto))
        {
            return Result.Fail($"All Customer Fields Must Be provided");
        }

        var customer = new Customer()
        {
            FirstName = customerDto.FirstName,
            LastName = customerDto.LastName,
            Email = customerDto.Email,
            PhoneNumber = customerDto.PhoneNumber
        };
        var customerId = _customerRepository.CreateCustomer(customer);
        return Result.Ok(customerId);
    }

    public Result<CustomerDto> UpdateCustomer(CustomerDto customerDto)
    {
        var customer = _customerRepository.FindCustomerById(customerDto.CustomerId);
        if (customer is null)
            Result.Fail($"No Customer with ID {customerDto.CustomerId} Exists");

        customer.FirstName = customerDto.FirstName ?? customer.FirstName;
        customer.LastName = customerDto.LastName ?? customer.LastName;
        customer.Email = customerDto.Email ?? customer.Email;
        customer.PhoneNumber = customerDto.PhoneNumber ?? customer.PhoneNumber;

        var updatedCustomer = _customerRepository.UpdateCustomer(customer);
        return Result.Ok(MapToCustomerDto(updatedCustomer));
    }

    public Result DeleteCustomer(int customerId)
    {
        if (!_customerRepository.HasCustomerById(customerId))
            throw new InvalidOperationException($"No Customer With ID {customerId} Exists");

        try
        {
            return Result.OkIf(_customerRepository.DeleteCustomer(customerId),
                $"Could Not Delete Customer With ID {customerId}");
        }
        catch (Exception e)
        {
            return Result.Fail(
                $"Could Not Delete Customer With ID {customerId}, It May Have Related Data");
        }
    }

    private CustomerDto MapToCustomerDto(Customer customer)
    {
        return new CustomerDto()
        {
            CustomerId = customer.CustomerId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber
        };
    }

    bool HasAnyNullOrEmptyFields(object myObject)
    {
        return
            (from propertyInfo in myObject.GetType().GetProperties()
                where propertyInfo.PropertyType == typeof(string)
                select (string)propertyInfo.GetValue(myObject))
            .Any(string.IsNullOrEmpty);
    }
}