using KolE.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolE.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NurseriesController : ControllerBase
{
    private readonly IDbService _dbService;

    public NurseriesController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}/batches")]
    public async Task<IActionResult> GetNurseriesBatches(int id)
    {
        try
        {
            var result = await _dbService.GetNursery(id);
            return Ok(result);
        }
        catch (ArgumentException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}