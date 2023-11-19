using RestaurantReservation.Db.KeylessEntities;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public interface IEmployeeRepository
{
    Task<int> CreateEmployee(Employee employee);
    Task<Employee> UpdateEmployee(Employee employee);
    Task<bool> DeleteEmployee(int employeeId);
    Task<Employee?> FindEmployeeById(int employeeId);
    Task<bool> HasEmployeeById(int employeeId);
    Task<List<Employee>> GetManagers();
    Task<double> CalculateAverageOrderAmount(int employeeId);
    Task<List<EmployeeDetails>> GetEmployeesDetails();
}