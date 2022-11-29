using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace RestAPI.Controllers;
[ApiController]
[Route("[controller]")]

public class PackageController : ControllerBase

{
    private readonly IPackageLogic packageLogic;

    public PackageController(IPackageLogic packageLogic)
    {
        this.packageLogic = packageLogic;
    }

    [HttpGet]
    public async Task<ActionResult<List<Package>>> GetAllAsync()
    {
        try
        {
            var packages = await packageLogic.GetAllAsync();
            return Ok(packages);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}