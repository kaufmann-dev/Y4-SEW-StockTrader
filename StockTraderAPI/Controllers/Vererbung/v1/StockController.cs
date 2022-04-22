using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Entities;

namespace StockTraderAPI.Controllers.Vererbung.v1;

[ApiController, ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/stocks")]
public class StockController : AController<Stock> {
    public StockController(IStockRepository repository, ILogger<StockController> logger) : base(repository, logger)
    {
    }
}