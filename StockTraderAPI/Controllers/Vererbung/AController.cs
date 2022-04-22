using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Entities;

namespace StockTraderAPI.Controllers; 

public abstract class AController<TEntity> : ControllerBase where TEntity : class{
    public IRepository<TEntity> _repository { get; set; }
    
    public ILogger<AController<TEntity>> _Logger { get; set; }

    public AController(IRepository<TEntity> repository, ILogger<AController<TEntity>> logger) {
        _repository = repository;
        _Logger = logger;
    }
    
    [HttpPost]
    public async Task<ActionResult<TEntity>> CreateAsync(TEntity entity) {
        var data = await _repository.CreateAsync(entity);
        if (data is null)
        {
            return BadRequest();
        }
        _Logger.LogInformation($"Created Entity {entity.ToString()}");
        return Ok(entity);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TEntity>> ReadAsync(int id) {
        var data = await _repository.ReadAsync(id);
        if (data is null)
            return NotFound();
        
        _Logger.LogInformation($"Loaded entity {id}");
        return Ok(data);
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<TEntity>>> ReadAllAsync() {
        var data = await _repository.ReadAllAsync();
        _Logger.LogInformation($"Loaded data {data.Count}");
        return Ok(data);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<TEntity>>> ReadAllAsync(int start, int count) {
        var data = await _repository.ReadAllAsync(start, count);
        _Logger.LogInformation($"Loaded data {data.Count}");
        return Ok(data);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateAsync(int id, TEntity entity) {
        var data = await _repository.ReadAsync(id);
        if (data is null)
            return NotFound();

        await _repository.UpdateAsync(entity);
        
        _Logger.LogInformation($"Updated entity {id}");

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAsync(int id) {
        var data = await _repository.ReadAsync(id);
        if (data is null)
            return NotFound();
        
        await _repository.DeleteAsync(data);
        _Logger.LogInformation($"Deleted entity {id}");
        return NoContent();
    }

    
}