using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Implementations;

public class ARepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected StockDbContext _testDbContext;
    protected DbSet<TEntity> _table;

    public ARepository(StockDbContext dbContext)
    {
        this._testDbContext = dbContext;
        _table = _testDbContext.Set<TEntity>();
    }

    public async Task<TEntity> ReadAsync(int id) => await _table.FindAsync(id);

    public async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter) =>
        await _table.Where(filter).ToListAsync();

    public async Task<List<TEntity>> ReadAllAsync() =>
        await _table.ToListAsync();

    public async Task<List<TEntity>> ReadAllAsync(int start, int count) =>
        await _table.Skip(start).Take(count).ToListAsync();

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        _table.Add(entity);
        await _testDbContext.SaveChangesAsync();
        return entity; // gibt die ID(Autoincremetn) vom Insert zurück für die Weiterverarbeitung
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _testDbContext.ChangeTracker.Clear();
        _table.Update(entity);
        await _testDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _table.Remove(entity);
        await _testDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _table.FindAsync(id);
        _table.Remove(data);
        await _testDbContext.SaveChangesAsync();
    }
}