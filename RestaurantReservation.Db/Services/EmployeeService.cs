using FluentResults;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IRestaurantRepository _restaurantRepository;

    public EmployeeService(IEmployeeRepository employeeRepository, IRestaurantRepository restaurantRepository)
    {
        _employeeRepository = employeeRepository;
        _restaurantRepository = restaurantRepository;
    }

    public Result<int> CreateEmployee(EmployeeDto employeeDto)
    {
        if (employeeDto.HasAnyNullOrEmptyFields())
            return Result.Fail($"All Employee Fields Must Be Provided");

        if (!_restaurantRepository.HasRestaurantById((int)employeeDto.RestaurantId!))
            return Result.Fail($"No Restaurant with ID {employeeDto.RestaurantId} Exists");


        var employee = new Employee()
        {
            FirstName = employeeDto.FirstName!,
            LastName = employeeDto.LastName!,
            Position = employeeDto.Position!,
            RestaurantId = (int)employeeDto.RestaurantId
        };
        var employeeId = _employeeRepository.CreateEmployee(employee);
        return Result.Ok(employeeId);
    }

    public Result<EmployeeDto> UpdateEmployee(EmployeeDto employeeDto)
    {
        var employee = _employeeRepository.FindEmployeeById(employeeDto.EmployeeId);
        if (employee is null)
            return Result.Fail($"No Employee with ID {employeeDto.EmployeeId} Exists");

        // TODO: Check for empty strings
        employee.FirstName = employeeDto.FirstName ?? employee.FirstName;
        employee.LastName = employeeDto.LastName ?? employee.LastName;
        employee.Position = employeeDto.Position ?? employee.Position;

        if (employeeDto.RestaurantId is not null)
        {
            if (!_restaurantRepository.HasRestaurantById((int)employeeDto.RestaurantId!))
                return Result.Fail($"No Restaurant with ID {employeeDto.RestaurantId} Exists");

            employee.RestaurantId = (int)employeeDto.RestaurantId;
        }


        var updatedEmployee = _employeeRepository.UpdateEmployee(employee);
        return Result.Ok(MapToEmployeeDto(updatedEmployee));
    }

    public Result DeleteEmployee(int employeeId)
    {
        if (!_employeeRepository.HasEmployeeById(employeeId))
            return Result.Fail($"No Employee With ID {employeeId} Exists");

        try
        {
            return Result.OkIf(_employeeRepository.DeleteEmployee(employeeId),
                $"Could Not Delete Employee With ID {employeeId}");
        }
        catch (Exception e)
        {
            return Result.Fail(
                $"Could Not Delete Employee With ID {employeeId}, It May Have Related Data");
        }
    }

    private EmployeeDto MapToEmployeeDto(Employee employee)
    {
        return new EmployeeDto()
        {
            EmployeeId = employee.EmployeeId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Position = employee.Position,
            RestaurantId = employee.RestaurantId
        };
    }
}