using FluentResults;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public Result<int> CreateEmployee(EmployeeDto employeeDto)
    {
        if (employeeDto.HasAnyNullOrEmptyFields())
        {
            return Result.Fail($"All Employee Fields Must Be Provided");
        }

        var employee = new Employee()
        {
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            Position = employeeDto.Position,
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

        employee.FirstName = employeeDto.FirstName ?? employee.FirstName;
        employee.LastName = employeeDto.LastName ?? employee.LastName;
        employee.Position = employeeDto.Position ?? employee.Position;
        employee.RestaurantId = employeeDto.RestaurantId ?? employee.RestaurantId;

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