using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers;

[Authorize]
[ApiController]
[Route("/api/employees")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    /// <summary>
    /// Gets a list of all employees.
    /// </summary>
    /// <returns>A list of employee DTOs.</returns>
    /// <response code="200">Returns a list of employees.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EmployeeDto>))]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
    {
        return Ok(await _employeeService.GetAllEmployees());
    }

    /// <summary>
    /// Gets an employee by ID.
    /// </summary>
    /// <param name="employeeId">The ID of the employee.</param>
    /// <returns>The employee DTO.</returns>
    /// <response code="200">Returns the requested employee.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmployeeDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [HttpGet("{employeeId:int}")]
    public async Task<ActionResult<EmployeeDto>> GetEmployee(int employeeId)
    {
        return Ok(await _employeeService.FindEmployeeById(employeeId));
    }

    /// <summary>
    /// Deletes an employee by ID.
    /// </summary>
    /// <param name="employeeId">The ID of the employee to delete.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">No content if the deletion is successful.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{employeeId:int}")]
    public async Task<ActionResult> DeleteEmployee(int employeeId)
    {
        await _employeeService.DeleteEmployee(employeeId);
        return NoContent();
    }

    /// <summary>
    /// Updates an employee by ID.
    /// </summary>
    /// <param name="employeeId">The ID of the employee to update.</param>
    /// <param name="employeeDto">The modified employee DTO.</param>
    /// <returns>The updated employee DTO.</returns>
    /// <response code="200">Returns the updated employee.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmployeeDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [HttpPut("{employeeId:int}")]
    public async Task<ActionResult<EmployeeDto>> UpdateEmployee(int employeeId, ModifyEmployeeDto employeeDto)
    {
        return Ok(await _employeeService.UpdateEmployee(employeeId, employeeDto));
    }

    /// <summary>
    /// Gets a list of all managers.
    /// </summary>
    /// <returns>A list of manager DTOs.</returns>
    /// <response code="200">Returns a list of managers.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EmployeeDto>))]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [HttpGet("managers")]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetManagers()
    {
        return Ok(await _employeeService.GetManagers());
    }

    /// <summary>
    /// Creates a new employee.
    /// </summary>
    /// <param name="employeeDto">The employee DTO for creation.</param>
    /// <returns>The ID of the created employee.</returns>
    /// <response code="200">Returns the ID of the created employee.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [HttpPost]
    public async Task<ActionResult> CreateEmployee(ModifyEmployeeDto employeeDto)
    {
        var employeeId = await _employeeService.CreateEmployee(employeeDto);
        return Ok(new { CreatedEmployeeId = employeeId });
    }

    /// <summary>
    /// Gets the average order amount for an employee by ID.
    /// </summary>
    /// <param name="employeeId">The ID of the employee.</param>
    /// <returns>The average order amount.</returns>
    /// <response code="200">Returns the average order amount for the employee.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(double))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [HttpGet("{employeeId:int}/average-order-amount")]
    public async Task<ActionResult<double>> GetAverageOrderAmount(int employeeId)
    {
        return Ok(await _employeeService.CalculateAverageOrderAmount(employeeId));
    }
}