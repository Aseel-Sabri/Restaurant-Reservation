using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.EntityOperations;

public class EmployeeOperations
{
    private readonly IEmployeeService _employeeService;

    public EmployeeOperations(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public void CreateEmployee()
    {
        var employeeDto = new EmployeeDto()
        {
            FirstName = "Khulood",
            LastName = "Sabri",
            Position = "Manager",
            RestaurantId = 1
        };


        var result = _employeeService.CreateEmployee(employeeDto);
        if (result.IsSuccess)
        {
            var createdEmployeeId = result.Value;
            Console.WriteLine($"Employee Added With ID {createdEmployeeId}");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public void UpdateEmployee()
    {
        var employeeDto = new EmployeeDto()
        {
            EmployeeId = 1,
            FirstName = "Mohammad",
            LastName = "Sabri"
        };

        var result = _employeeService.UpdateEmployee(employeeDto);
        if (result.IsSuccess)
        {
            Console.WriteLine($"Updated Employee: {Environment.NewLine}{result.Value}");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }


    public void DeleteEmployee(int employeeId)
    {
        var result = _employeeService.DeleteEmployee(employeeId);

        if (result.IsSuccess)
        {
            Console.WriteLine($"Employee With ID {employeeId} Deleted Successfully");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }
}