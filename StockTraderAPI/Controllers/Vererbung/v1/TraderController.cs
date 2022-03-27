using System.Threading.Tasks;
using Domain.Implementations;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Entities;

namespace StockTraderAPI.Controllers.Vererbung.v1; 

[ApiController, ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/traders")]
public class TraderController : AController<Trader> {
    public TraderController(IRepository<Trader> repository, ILogger<TraderController> logger) : base(repository, logger) { }

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