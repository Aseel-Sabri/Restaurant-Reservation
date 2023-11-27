using FluentResults;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.KeylessEntities;
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

    public async Task<Result<int>> CreateEmployee(EmployeeDto employeeDto)
    {
        if (employeeDto.HasAnyNullOrEmptyFields())
            return Result.Fail($"All Employee Fields Must Be Provided");

        if (!await _restaurantRepository.HasRestaurantById((int)employeeDto.RestaurantId!))
            return Result.Fail($"No Restaurant with ID {employeeDto.RestaurantId} Exists");


        var employee = new Employee()
        {
            FirstName = employeeDto.FirstName!,
            LastName = employeeDto.LastName!,
            Position = employeeDto.Position!,
            RestaurantId = (int)employeeDto.RestaurantId
        };
        var employeeId = await _employeeRepository.CreateEmployee(employee);
        return Result.Ok(employeeId);
    }

    public async Task<Result<EmployeeDto>> UpdateEmployee(EmployeeDto employeeDto)
    {
        var employee = await _employeeRepository.FindEmployeeById(employeeDto.EmployeeId);
        if (employee is null)
            return Result.Fail($"No Employee with ID {employeeDto.EmployeeId} Exists");

        // TODO: Check for empty strings
        employee.FirstName = employeeDto.FirstName ?? employee.FirstName;
        employee.LastName = employeeDto.LastName ?? employee.LastName;
        employee.Position = employeeDto.Position ?? employee.Position;

        if (employeeDto.RestaurantId is not null)
        {
            if (!await _restaurantRepository.HasRestaurantById((int)employeeDto.RestaurantId!))
                return Result.Fail($"No Restaurant with ID {employeeDto.RestaurantId} Exists");

            employee.RestaurantId = (int)employeeDto.RestaurantId;
        }


        var updatedEmployee = await _employeeRepository.UpdateEmployee(employee);
        return Result.Ok(MapToEmployeeDto(updatedEmployee));
    }

    public async Task<Result> DeleteEmployee(int employeeId)
    {
        if (!await _employeeRepository.HasEmployeeById(employeeId))
            return Result.Fail($"No Employee With ID {employeeId} Exists");

        try
        {
            return Result.OkIf(await _employeeRepository.DeleteEmployee(employeeId),
                $"Could Not Delete Employee With ID {employeeId}");
        }
        catch (Exception e)
        {
            return Result.Fail(
                $"Could Not Delete Employee With ID {employeeId}, It May Have Related Data");
        }
    }

    public async Task<List<EmployeeDto>> GetManagers()
    {
        return (await _employeeRepository.GetManagers()).Select(MapToEmployeeDto).ToList();
    }

    public async Task<List<EmployeeDetails>> GetEmployeesDetails()
    {
        return await _employeeRepository.GetEmployeesDetails();
    }

    public async Task<Result<double>> CalculateAverageOrderAmount(int employeeId)
    {
        if (!await _employeeRepository.HasEmployeeById(employeeId))
            return Result.Fail($"No Employee With ID {employeeId} Exists");

        return await _employeeRepository.CalculateAverageOrderAmount(employeeId);
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