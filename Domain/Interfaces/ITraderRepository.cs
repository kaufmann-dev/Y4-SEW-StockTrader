using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Entities;

namespace Domain.Interfaces; 

public interface ITraderRepository : IRepository<Trader> {
    Task<List<Trader>> ReadGraphAsync(int id);
}