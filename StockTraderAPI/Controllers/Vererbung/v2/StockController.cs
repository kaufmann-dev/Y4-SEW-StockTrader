using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Entities;

namespace StockTraderAPI.Controllers.v2; 

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/stocks")]
public class StockController : AController<Stock> {
    public StockController(IRepository<Stock> repository, ILogger<AController<Stock>> logger) : base(repository, logger)
    {
    }
}