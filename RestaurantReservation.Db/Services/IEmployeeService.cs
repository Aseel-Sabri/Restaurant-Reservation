using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.ValueObjects;

namespace RestaurantReservation.Db.Services;

public interface IEmployeeService
{
    Task<int> CreateEmployee(ModifyEmployeeDto employeeDto);
    Task<EmployeeDto> UpdateEmployee(int employeeId, ModifyEmployeeDto employeeDto);
    Task DeleteEmployee(int employeeId);
    Task<List<EmployeeDto>> GetManagers();
    Task<double> CalculateAverageOrderAmount(int employeeId);
    Task<List<EmployeeDetails>> GetEmployeesDetails();
    Task<EmployeeDto> FindEmployeeById(int employeeId);
    Task<List<Employee>> GetAllEmployees();
}