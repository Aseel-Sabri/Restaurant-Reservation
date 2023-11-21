using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.DbContext;
using RestaurantReservation.Db.KeylessEntities;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly RestaurantReservationDbContext _dbContext;

    public EmployeeRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateEmployee(Employee employee)
    {
        await _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync();
        return employee.EmployeeId;
    }

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        _dbContext.Entry(employee).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return (await FindEmployeeById(employee.EmployeeId));
    }

    public async Task<bool> DeleteEmployee(int employeeId)
    {
        var employee = await FindEmployeeById(employeeId);
        _dbContext.Employees.Remove(employee);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<List<Employee>> GetManagers()
    {
        var position = "Manager";
        return await _dbContext.Employees.Where(employee => employee.Position == position).ToListAsync();
    }

    public async Task<double> CalculateAverageOrderAmount(int employeeId)
    {
        return await _dbContext.Orders
            .Where(order => order.EmployeeId == employeeId)
            .AverageAsync(order => order.TotalAmount);
    }

    public async Task<List<EmployeeDetails>> GetEmployeesDetails()
    {
        return await _dbContext.EmployeesDetails.ToListAsync();
    }

    public async Task<List<Employee>> GetAllEmployees()
    {
        return await _dbContext.Employees.ToListAsync();
    }

    public async Task<Employee?> FindEmployeeById(int employeeId)
    {
        return await _dbContext.Employees.FindAsync(employeeId);
    }

    public async Task<bool> HasEmployeeById(int employeeId)
    {
        return await FindEmployeeById(employeeId) is not null;
    }
}