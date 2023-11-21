using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("/api/customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
    {
        return Ok(await _customerService.GetAllCustomers());
    }

    [HttpGet("{customerId}")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(int customerId)
    {
        return Ok(await _customerService.FindCustomerById(customerId));
    }

    [HttpDelete("{customerId}")]
    public async Task<ActionResult> DeleteCustomer(int customerId)
    {
        await _customerService.DeleteCustomer(customerId);
        return NoContent();
    }

    [HttpPut("{customerId}")]
    public async Task<ActionResult<EmployeeDto>> UpdateCustomer(int customerId, ModifyCustomerDto customerDto)
    {
        return Ok(await _customerService.UpdateCustomer(customerId, customerDto));
    }

    [HttpPost]
    public async Task<ActionResult> CreateEmployee(ModifyCustomerDto customerDto)
    {
        var customerId = await _customerService.CreateCustomer(customerDto);
        return Ok(new { CreatedCustomerId = customerId });
    }
}