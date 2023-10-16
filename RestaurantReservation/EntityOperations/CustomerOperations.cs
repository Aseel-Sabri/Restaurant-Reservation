﻿using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.EntityOperations;

public class CustomerOperations
{
    private readonly ICustomerService _customerService;

    public CustomerOperations(ICustomerService customerService)
    {
        _customerService = customerService;
    }


    public void CreateCustomer()
    {
        var customerDto = new CustomerDto()
        {
            FirstName = "Aseel",
            LastName = "Sabri",
            Email = "aseel.sabri@example.com",
            PhoneNumber = "111-2222"
        };


        var result = _customerService.CreateCustomer(customerDto);
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

    public void UpdateCustomer()
    {
        var customerDto = new CustomerDto()
        {
            CustomerId = 5,
            FirstName = "Leen",
            LastName = "Sabri",
            Email = "leen.sabri@example.com"
        };

        var result = _customerService.UpdateCustomer(customerDto);
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

    public void DeleteCustomer(int customerId)
    {
        var result = _customerService.DeleteCustomer(customerId);

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
}