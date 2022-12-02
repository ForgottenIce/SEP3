using gRPC.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Models;

namespace RestAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerLogic _customerLogic;

    [HttpPost]
    public async Task<ActionResult<Customer>> CreateCustomerAsync(CustomerCreationDto dto)
    {
        try
        {
            Customer customer = await _customerLogic.CreateCustomerAsync(dto);
            return Created($"/Customer/{customer.Id}", customer);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomerByIdAsync([FromRoute] long id) {
        try {
            Customer customer = await _customerLogic.GetCustomerByIdAsync(id);
            return Ok(customer);
        }
        catch(Exception e) {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersAsync() {
        try {
            IEnumerable<Customer> customer = await _customerLogic.GetCustomersAsync();
            return Ok(customer);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
}
