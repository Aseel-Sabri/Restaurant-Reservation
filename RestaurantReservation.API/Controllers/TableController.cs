using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("/api/tables")]
public class TableController : ControllerBase
{
    private readonly ITableService _tableService;

    public TableController(ITableService tableService)
    {
        _tableService = tableService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TableDto>>> GetTables()
    {
        return Ok(await _tableService.GetAllTables());
    }

    [HttpGet("{tableId:int}")]
    public async Task<ActionResult<TableDto>> GetTable(int tableId)
    {
        return Ok(await _tableService.FindTableById(tableId));
    }

    [HttpDelete("{tableId:int}")]
    public async Task<ActionResult> DeleteTableReservation(int tableId)
    {
        await _tableService.DeleteTable(tableId);
        return NoContent();
    }

    [HttpPut("{tableId:int}")]
    public async Task<ActionResult<ReservationDto>> UpdateTable(int tableId, UpdateTableDto tableDto)
    {
        return Ok(await _tableService.UpdateTable(tableId, tableDto));
    }

    [HttpPost]
    public async Task<ActionResult> CreateTable(CreateTableDto tableDto)
    {
        var tableId = await _tableService.CreateTable(tableDto);
        return Ok(new { CreatedTableId = tableId });
    }
}