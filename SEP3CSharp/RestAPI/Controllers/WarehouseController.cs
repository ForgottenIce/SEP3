using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace RestAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WarehouseController : ControllerBase {
    private readonly IWarehouseLogic _warehouseLogic;

    public WarehouseController(IWarehouseLogic warehouseLogic) {
        _warehouseLogic = warehouseLogic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Warehouse>>> GetWarehousesAsync() {
        try {
            IEnumerable<Warehouse> warehouses = await _warehouseLogic.GetWarehousesAsync();
            return Ok(warehouses);
        }
        catch(Exception e) {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Warehouse>> GetWarehouseByIdAsync([FromRoute] long id) {
        try {
            Warehouse warehouse = await _warehouseLogic.GetWarehouseByIdAsync(id);
            return Ok(warehouse);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}
