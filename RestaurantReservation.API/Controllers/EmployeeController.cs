using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("/api/employees")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
    {
        return Ok(await _employeeService.GetAllEmployees());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
    {
        return Ok(await _employeeService.FindEmployeeById(id));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        await _employeeService.DeleteEmployee(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EmployeeDto>> UpdateEmployee(int id, ModifyEmployeeDto employeeDto)
    {
        return Ok(await _employeeService.UpdateEmployee(id, employeeDto));
    }

    [HttpGet("managers")]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetManagers()
    {
        return Ok(await _employeeService.GetManagers());
    }

    [HttpPost]
    public async Task<ActionResult> CreateEmployee(ModifyEmployeeDto employeeDto)
    {
        var employeeId = await _employeeService.CreateEmployee(employeeDto);
        return Ok(new { CreatedEmployeeId = employeeId });
    }

    [HttpGet("{employeeId:int}/average-order-amount")]
    public async Task<ActionResult<double>> GetAverageOrderAmount(int employeeId)
    {
        return Ok(await _employeeService.CalculateAverageOrderAmount(employeeId));
    }
}