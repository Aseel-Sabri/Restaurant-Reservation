using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.EntityOperations;

public class CustomerOperations
{
    private readonly ICustomerService _customerService;

    public CustomerOperations(ICustomerService customerService)
    {
        _customerService = customerService;
    }


    public async Task CreateCustomer()
    {
        var customerDto = new CustomerDto()
        {
            FirstName = "Aseel",
            LastName = "Sabri",
            Email = "aseel.sabri@example.com",
            PhoneNumber = "111-2222"
        };


        var result = await _customerService.CreateCustomer(customerDto);
        if (result.IsSuccess)
        {
            var createdCustomerId = result.Value;
            Console.WriteLine($"Customer Added With ID {createdCustomerId}");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public async Task UpdateCustomer()
    {
        var customerDto = new CustomerDto()
        {
            CustomerId = 5,
            FirstName = "Leen",
            LastName = "Sabri",
            Email = "leen.sabri@example.com"
        };

        var result = await _customerService.UpdateCustomer(customerDto);
        if (result.IsSuccess)
        {
            Console.WriteLine($"Updated Customer: {Environment.NewLine}{result.Value}");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public async Task DeleteCustomer(int customerId)
    {
        var result = await _customerService.DeleteCustomer(customerId);

        if (result.IsSuccess)
        {
            Console.WriteLine($"Customer With ID {customerId} Deleted Successfully");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public async Task FindCustomersWithPartySizeGreaterThan(int partySize)
    {
        var customerDtos = await _customerService.FindCustomersWithPartySizeGreaterThan(partySize);
        if (!customerDtos.Any())
        {
            Console.WriteLine("No Customers Were Found");
            Console.WriteLine();
            return;
        }

        customerDtos.ForEach(customer =>
        {
            Console.WriteLine(customer);
            Console.WriteLine();
        });
    }
}