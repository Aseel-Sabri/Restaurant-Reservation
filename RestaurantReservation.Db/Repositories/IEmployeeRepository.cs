using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public interface IEmployeeRepository
{
    int CreateEmployee(Employee employee);
    Employee UpdateEmployee(Employee employee);
    bool DeleteEmployee(int employeeId);
    Employee? FindEmployeeById(int employeeId);
    bool HasEmployeeById(int employeeId);
    List<Employee> GetManagers();
}