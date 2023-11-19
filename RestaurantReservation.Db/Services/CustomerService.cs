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

    public async Task<Result<int>> CreateCustomer(CustomerDto customerDto)
    {
        if (customerDto.HasAnyNullOrEmptyFields())
        {
            return Result.Fail($"All Customer Fields Must Be Provided");
        }

        var customer = new Customer()
        {
            FirstName = customerDto.FirstName,
            LastName = customerDto.LastName,
            Email = customerDto.Email,
            PhoneNumber = customerDto.PhoneNumber
        };
        var customerId = await _customerRepository.CreateCustomer(customer);
        return Result.Ok(customerId);
    }

    public async Task<Result<CustomerDto>> UpdateCustomer(CustomerDto customerDto)
    {
        var customer = await _customerRepository.FindCustomerById(customerDto.CustomerId);
        if (customer is null)
            return Result.Fail($"No Customer with ID {customerDto.CustomerId} Exists");

        // TODO: Check for empty strings
        customer.FirstName = customerDto.FirstName ?? customer.FirstName;
        customer.LastName = customerDto.LastName ?? customer.LastName;
        customer.Email = customerDto.Email ?? customer.Email;
        customer.PhoneNumber = customerDto.PhoneNumber ?? customer.PhoneNumber;

        var updatedCustomer = await _customerRepository.UpdateCustomer(customer);
        return Result.Ok(MapToCustomerDto(updatedCustomer));
    }

    public async Task<Result> DeleteCustomer(int customerId)
    {
        if (!await _customerRepository.HasCustomerById(customerId))
            return Result.Fail($"No Customer With ID {customerId} Exists");

        try
        {
            return Result.OkIf(await _customerRepository.DeleteCustomer(customerId),
                $"Could Not Delete Customer With ID {customerId}");
        }
        catch (Exception e)
        {
            return Result.Fail(
                $"Could Not Delete Customer With ID {customerId}, It May Have Related Data");
        }
    }

    public async Task<List<CustomerDto>> FindCustomersWithPartySizeGreaterThan(int partySize)
    {
        return (await _customerRepository.FindCustomersWithPartySizeGreaterThan(partySize))
            .Select(MapToCustomerDto)
            .ToList();
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
}