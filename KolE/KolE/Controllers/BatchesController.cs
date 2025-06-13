using KolE.DTOs;
using KolE.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolE.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BatchesController : ControllerBase
{
    private readonly IDbService _dbService;

    public BatchesController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddSeedlingBatches(AddSeedlingBatchDto addBatchDto)
    {
        try
        {
            await _dbService.AddSeedlingBatches(addBatchDto);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}