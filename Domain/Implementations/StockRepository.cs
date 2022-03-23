using Model.Configurations;
using Model.Entities;

namespace Domain.Implementations;

public class StockRepository: ARepository<Stock>
{
    public StockRepository(StockDbContext dbContext) : base(dbContext)
    {
    }
}