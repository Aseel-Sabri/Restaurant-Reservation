using FluentResults;
using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.Db.Services;

public interface IEmployeeService
{
    Result<int> CreateEmployee(EmployeeDto employeeDto);
    Result<EmployeeDto> UpdateEmployee(EmployeeDto employeeDto);
    Result DeleteEmployee(int employeeId);
}