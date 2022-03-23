using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Implementations;

public class TraderRepository : ARepository<Trader>, ITraderRepository
{
    public TraderRepository(StockDbContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<List<Trader>> ReadGraphAsync(int id) =>
        await _table.Include(t => t.Tradings).ThenInclude(t => t.Stock).ToListAsync();
}