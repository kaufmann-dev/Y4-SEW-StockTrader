using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Entities;

namespace StockTraderAPI.Controllers.v1; 

[ApiController, ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/traders")]
public class TraderController : AController<Trader> {
    public TraderController(ITraderRepository repository, ILogger<TraderController> logger) : base(repository, logger) { }

    /*[HttpGet("graph/{id:int}")]
    public async Task<ActionResult> ReadGraphAsync(int id)
    {
        await _repository.ReadGraphAsync(id);
    }*/


}