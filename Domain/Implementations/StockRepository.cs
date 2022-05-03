using Domain.Interfaces;
using Model.Configurations;
using Model.Entities;

namespace Domain.Implementations;

public class StockRepository: ARepository<Stock>,IStockRepository
{
    public StockRepository(StockDbContext dbContext) : base(dbContext)
    {
    }
}