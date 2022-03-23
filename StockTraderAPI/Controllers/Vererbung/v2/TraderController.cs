using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Entities;

namespace StockTraderAPI.Controllers.v2;

[ApiVersion("2.0")]
[ApiController]
[Route("api/v{version:apiVersion}/traders")]
public class TraderController : AController<Trader>
{
    public TraderController(IRepository<Trader> repository, ILogger<AController<Trader>> logger) : base(repository, logger)
    {
    }
}