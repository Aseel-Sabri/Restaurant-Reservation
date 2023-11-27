using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers;

[Authorize]
[ApiController]
[Route("/api/customers")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    /// <summary>
    /// Gets a list of all customers.
    /// </summary>
    /// <returns>A list of customer DTOs.</returns>
    /// <response code="200">Returns a list of customers.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDto>))]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
    {
        return Ok(await _customerService.GetAllCustomers());
    }

    /// <summary>
    /// Gets a customer by ID.
    /// </summary>
    /// <returns>The customer DTO.</returns>
    /// <param name="customerId">The ID of the customer.</param>
    /// <response code="200">Returns the requested customer.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [HttpGet("{customerId:int}")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(int customerId)
    {
        return Ok(await _customerService.FindCustomerById(customerId));
    }

    /// <summary>
    /// Deletes a customer by ID.
    /// </summary>
    /// <param name="customerId">The ID of the customer to delete.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">If the customer is successfully deleted.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{customerId:int}")]
    public async Task<ActionResult> DeleteCustomer(int customerId)
    {
        await _customerService.DeleteCustomer(customerId);
        return NoContent();
    }

    /// <summary>
    /// Updates a customer by ID.
    /// </summary>
    /// <param name="customerId">The ID of the customer to update.</param>
    /// <param name="customerDto">The modified customer DTO.</param>
    /// <returns>The updated customer DTO.</returns>
    /// <response code="200">Returns the updated customer.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [HttpPut("{customerId:int}")]
    public async Task<ActionResult<CustomerDto>> UpdateCustomer(int customerId, ModifyCustomerDto customerDto)
    {
        return Ok(await _customerService.UpdateCustomer(customerId, customerDto));
    }

    /// <summary>
    /// Creates a new customer.
    /// </summary>
    /// <param name="customerDto">The customer DTO for creation.</param>
    /// <returns>The ID of the created customer.</returns>
    /// <response code="200">Returns the ID of the created customer.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [HttpPost]
    public async Task<ActionResult> CreateCustomer(ModifyCustomerDto customerDto)
    {
        var customerId = await _customerService.CreateCustomer(customerDto);
        return Ok(new { CreatedCustomerId = customerId });
    }
}