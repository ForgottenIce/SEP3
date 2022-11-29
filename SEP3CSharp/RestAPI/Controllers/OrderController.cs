using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Models;

namespace RestAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase {

    private readonly IOrderLogic _orderLogic;

    public OrderController(IOrderLogic orderLogic) {
        _orderLogic = orderLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrderAsync(OrderCreationDto dto) {
        try {
            Order order = await _orderLogic.CreateOrderAsync(dto);
            return Created($"/order/{order.Id}", order);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<Order>> GetOrderByIdAsync([FromRoute] long id) {
        try {
            Order order = await _orderLogic.GetOrderByIdAsync(id);
            return Ok(order);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}
