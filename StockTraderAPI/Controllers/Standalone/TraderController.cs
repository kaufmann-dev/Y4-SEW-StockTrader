using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Entities;

namespace StockTraderAPI.Controllers.Standalone;

[ApiController]
[Route("api/traders")]
public class TraderController : ControllerBase
{
    public ITraderRepository _repo { get; set; }
    public Logger<TraderController> _logger { get; set; }

    public TraderController(ITraderRepository repo, Logger<TraderController> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    // Create
    [HttpPost]
    public async Task<ActionResult> CreateAsync(Trader trader)
    {
        var data = await _repo.CreateAsync(trader);
        if (data is null)
        {
            return BadRequest();
        }
        return Ok();
    }

    // Read single
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Trader>> ReadAsync(int id)
    {
        var data = await _repo.ReadAsync(id);
        if (data is null)
        {
            return NotFound();
        }
        return Ok(data);
    }

    // Read all
    [HttpGet("all")]
    public async Task<ActionResult<List<Trader>>> ReadAllAsync()
    {
        var data = await _repo.ReadAllAsync();
        if (data is null)
        {
            return NotFound();
        }
        return Ok(data);
    }
    
    // Read from start to end
    [HttpGet]
    public async Task<ActionResult<List<Trader>>> ReadFromStartToEnd(int start, int end)
    {
        var data = await _repo.ReadAllAsync(start, end);
        if (data is null)
        {
            return NotFound();
        }
        return Ok(data);
    }
    
    // Read graph
    [HttpGet("graph/{id:int}")]
    public async Task<ActionResult<List<Trader>>> ReadGraphAsnyc(int id)
    {
        var data = await _repo.ReadGraphAsync(id);
        if (data is null)
        {
            return NotFound();
        }
        return Ok(data);
    }
    
    // Delete by id
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var data = await _repo.ReadAsync(id);
        if (data is null)
        {
            return NotFound();
        }
        await _repo.DeleteAsync(id);
        return NoContent();
    }

    // Delete by object
    [HttpDelete]
    public async Task<ActionResult> DeleteAsyncObj(Trader trader)
    {
        if (trader is null)
        {
            return BadRequest();
        }

        await _repo.DeleteAsync(trader);
        return NoContent();
    }
    
    // Update
    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateAsnyc(Trader trader, int id)
    {
        var data = await  _repo.ReadAsync(id);
        if (data is null || trader.TraderId != id)
        {
            return NotFound();
        }

        await _repo.UpdateAsync(trader);
        return Ok();
    }

    // Ping
    [HttpGet("ping")]
    public async Task<ActionResult<string>> Ping()
    {
        return "pong";
    }
    
}