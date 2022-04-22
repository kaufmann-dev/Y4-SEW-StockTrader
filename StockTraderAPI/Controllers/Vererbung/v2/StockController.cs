using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Entities;
using StockTraderAPI.Controllers;

namespace StockTraderAPI.Controllers.Vererbung.v2;

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/stocks")]
public class StockController : AController<Stock> {
    public StockController(IStockRepository repository, ILogger<StockController> logger) : base(repository, logger)
    {
    }
}