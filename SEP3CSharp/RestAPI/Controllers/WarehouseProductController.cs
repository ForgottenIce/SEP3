using Application.Logic;
using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Models;


namespace RestAPI.Controllers;


[ApiController]
[Route("[controller]")]

public class WarehouseProductController : ControllerBase
{
    private readonly IWarehouseProductLogic _warehouseProductLogic;

    public WarehouseProductController(IWarehouseProductLogic warehouseProductLogic)
    {
        this._warehouseProductLogic = warehouseProductLogic;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WarehouseProduct>>> GetAllAsync() {
        try
        {
            IEnumerable<WarehouseProduct> warehouseProducts = await ;
            return Ok(warehouseProducts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<WarehouseProduct>> GetWarehouseProductByIdAsync([FromRoute] long id) {
        try
        {
            WarehouseProduct warehouseProduct = await _warehouseProductLogic.GetWarehouseProductAsync(id);
            return Ok(warehouseProduct);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCodes(500, e.Message);
        }
        
    }
}