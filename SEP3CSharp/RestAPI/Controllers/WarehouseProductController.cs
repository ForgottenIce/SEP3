using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Exceptions;
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

    [HttpPost]
    public async Task<ActionResult<WarehouseProduct>> CreateWarehouseProduct(WarehouseProductCreationDto dto) {
        try {
            WarehouseProduct warehouseProduct = await _warehouseProductLogic.CreateWarehouseProduct(dto);
            return Ok(warehouseProduct);
        }
        catch (AlreadyExistsException e) {
            Console.WriteLine(e.Message);
            return Conflict(e.Message);
        }
        catch (NotFoundException e) {
            Console.WriteLine(e.Message);
            return Conflict(e.Message);
        }
        catch (ServiceUnavailableException e) {
            Console.WriteLine(e);
            return StatusCode(503, e.Message);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WarehouseProduct>>> GetAllAsync() {
        try
        {
            IEnumerable<WarehouseProduct> warehouseProducts = await _warehouseProductLogic.GetWarehouseProductsAsync();
            return Ok(warehouseProducts);
        }
        catch (ServiceUnavailableException e) {
            Console.WriteLine(e);
            return StatusCode(503, e.Message);
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
            WarehouseProduct warehouseProduct = await _warehouseProductLogic.GetWarehouseProductByIdAsync(id);
            return Ok(warehouseProduct);

        }
        catch (NotFoundException e) {
            Console.WriteLine(e.Message);
            return NotFound(e.Message);
        }
        catch (ServiceUnavailableException e) {
            Console.WriteLine(e);
            return StatusCode(503, e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}