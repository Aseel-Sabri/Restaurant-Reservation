using FluentResults;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.KeylessEntities;

namespace RestaurantReservation.Db.Services;

public interface IEmployeeService
{
    Result<int> CreateEmployee(EmployeeDto employeeDto);
    Result<EmployeeDto> UpdateEmployee(EmployeeDto employeeDto);
    Result DeleteEmployee(int employeeId);
    List<EmployeeDto> GetManagers();
    Result<double> CalculateAverageOrderAmount(int employeeId);
    List<EmployeeDetails> GetEmployeesDetails();
}