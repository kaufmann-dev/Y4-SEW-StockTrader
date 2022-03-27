using Domain.Implementations;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Entities;

namespace StockTraderAPI.Controllers.Vererbung.v2;

[ApiVersion("2.0")]
[ApiController]
[Route("api/v{version:apiVersion}/traders")]
public class TraderController : AController<Trader>
{
    public TraderController(IRepository<Trader> repository, ILogger<AController<Trader>> logger) : base(repository, logger)
    {
    }
    
    [HttpGet("graph/{id:int}")]
    public async Task<ActionResult<List<Trader>>> ReadGraphAsnyc(int id)
    {
        var data = await ((TraderRepository) _repository).ReadGraphAsync(id);
        if (data is null)
        {
            return NotFound();
        }

        return Ok(data);
    }
}