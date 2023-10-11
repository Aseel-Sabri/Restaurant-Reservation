using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly RestaurantReservationDbContext _dbContext;

    public EmployeeRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int CreateEmployee(Employee employee)
    {
        _dbContext.Employees.Add(employee);
        _dbContext.SaveChanges();
        return employee.EmployeeId;
    }

    public Employee UpdateEmployee(Employee employee)
    {
        _dbContext.Entry(employee).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return FindEmployeeById(employee.EmployeeId);
    }

    public bool DeleteEmployee(int employeeId)
    {
        var employee = FindEmployeeById(employeeId);
        _dbContext.Employees.Remove(employee);
        return _dbContext.SaveChanges() > 0;
    }

    public Employee? FindEmployeeById(int employeeId)
    {
        return _dbContext.Employees.Find(employeeId);
    }

    public bool HasEmployeeById(int employeeId)
    {
        return FindEmployeeById(employeeId) is not null;
    }
}