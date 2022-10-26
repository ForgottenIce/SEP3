using gRPC;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<long[]>> GetPingAsync()
    {
        try
        {
            PingResponse created = await Class1.PingServerAsync();
            return Ok(new long[] { created.OriginDate, created.ReturnDate });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}