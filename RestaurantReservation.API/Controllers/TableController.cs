using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers;

[Authorize]
[ApiController]
[Route("/api/tables")]
public class TableController : ControllerBase
{
    private readonly ITableService _tableService;

    public TableController(ITableService tableService)
    {
        _tableService = tableService;
    }

    /// <summary>
    /// Gets a list of all tables.
    /// </summary>
    /// <returns>A list of table DTOs.</returns>
    /// <response code="200">Returns a list of tables.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TableDto>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TableDto>>> GetTables()
    {
        return Ok(await _tableService.GetAllTables());
    }

    /// <summary>
    /// Gets a table by ID.
    /// </summary>
    /// <param name="tableId">The ID of the table.</param>
    /// <returns>The table DTO.</returns>
    /// <response code="200">Returns the requested table.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TableDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet("{tableId:int}")]
    public async Task<ActionResult<TableDto>> GetTable(int tableId)
    {
        return Ok(await _tableService.FindTableById(tableId));
    }

    /// <summary>
    /// Deletes a table by ID.
    /// </summary>
    /// <param name="tableId">The ID of the table to delete.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">No content if the deletion is successful.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpDelete("{tableId:int}")]
    public async Task<ActionResult> DeleteTable(int tableId)
    {
        await _tableService.DeleteTable(tableId);
        return NoContent();
    }

    /// <summary>
    /// Updates a table by ID.
    /// </summary>
    /// <param name="tableId">The ID of the table to update.</param>
    /// <param name="tableDto">The updated table DTO.</param>
    /// <returns>The updated table DTO.</returns>
    /// <response code="200">Returns the updated table.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TableDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPut("{tableId:int}")]
    public async Task<ActionResult<TableDto>> UpdateTable(int tableId, UpdateTableDto tableDto)
    {
        return Ok(await _tableService.UpdateTable(tableId, tableDto));
    }

    /// <summary>
    /// Creates a new table.
    /// </summary>
    /// <param name="tableDto">The table DTO for creation.</param>
    /// <returns>The ID of the created table.</returns>
    /// <response code="200">Returns the ID of the created table.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost]
    public async Task<ActionResult> CreateTable(CreateTableDto tableDto)
    {
        var tableId = await _tableService.CreateTable(tableDto);
        return Ok(new { CreatedTableId = tableId });
    }
}