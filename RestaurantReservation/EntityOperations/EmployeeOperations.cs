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

    public async Task CreateEmployee()
    {
        var employeeDto = new EmployeeDto()
        {
            FirstName = "Khulood",
            LastName = "Sabri",
            Position = "Manager",
            RestaurantId = 1
        };


        var result = await _employeeService.CreateEmployee(employeeDto);
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

    public async Task UpdateEmployee()
    {
        var employeeDto = new EmployeeDto()
        {
            EmployeeId = 1,
            FirstName = "Mohammad",
            LastName = "Sabri"
        };

        var result = await _employeeService.UpdateEmployee(employeeDto);
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


    public async Task DeleteEmployee(int employeeId)
    {
        var result = await _employeeService.DeleteEmployee(employeeId);

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

    public async Task ListManagers()
    {
        (await _employeeService.GetManagers())
            .ForEach(manager =>
            {
                Console.WriteLine(manager);
                Console.WriteLine();
            });
    }

    public async Task CalculateAverageOrderAmount(int employeeId)
    {
        var result = await _employeeService.CalculateAverageOrderAmount(employeeId);

        if (result.IsFailed)
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
            Console.WriteLine();
            return;
        }

        Console.WriteLine(result.Value);
        Console.WriteLine();
    }

    public async Task GetEmployeesDetails()
    {
        var employeesDetails = await _employeeService.GetEmployeesDetails();

        if (!employeesDetails.Any())
        {
            Console.WriteLine($"No Employees Were Added");
            return;
        }

        employeesDetails.ForEach(employeeDetails =>
        {
            Console.WriteLine(employeeDetails);
            Console.WriteLine();
        });
    }
}