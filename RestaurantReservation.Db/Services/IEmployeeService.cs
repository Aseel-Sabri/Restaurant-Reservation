using FluentResults;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.KeylessEntities;

namespace RestaurantReservation.Db.Services;

public interface IEmployeeService
{
    Task<Result<int>> CreateEmployee(EmployeeDto employeeDto);
    Task<Result<EmployeeDto>> UpdateEmployee(EmployeeDto employeeDto);
    Task<Result> DeleteEmployee(int employeeId);
    Task<List<EmployeeDto>> GetManagers();
    Task<Result<double>> CalculateAverageOrderAmount(int employeeId);
    Task<List<EmployeeDetails>> GetEmployeesDetails();
}