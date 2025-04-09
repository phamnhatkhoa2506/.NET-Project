using Microsoft.AspNetCore.Mvc;
using BackEnd.Services;
using BackEnd.Models;

public class BaseController<T> : ControllerBase 
    where T : NameBase
{
    protected readonly ILogger<BaseController<T>> _logger;

    protected readonly BaseServices<T> Services;

    public BaseController(ILogger<BaseController<T>> logger, BaseServices<T> services)
    {
        this._logger = logger;
        this.Services = services;
    }

    protected async Task<ActionResult<List<T>>> GetAll()
    {
        var entities = await this.Services.GetAll();
        if (entities is null)
            return NotFound("Not Found");

        return Ok(entities);
    }

    protected async Task<ActionResult<T>> GetWithID(Guid id)
    {
        T? entity = await this.Services.GetWithID(id);
        if (entity is null)
            return NotFound("Not Found");

        return Ok(entity);
    }

    protected async Task<ActionResult<T>> Post([FromBody] T entity)
    {
        var newEntity = await this.Services.Add(entity);
        if (newEntity is null)
            return new ConflictObjectResult("Already exist");
        return Ok(newEntity);
    }

    protected async Task<ActionResult> Delete(Guid id)
    {
        bool isDeleted = await this.Services.Delete(id);
        if (!isDeleted)
            return NotFound("Not Found");
        
        return Ok(new {message = "Deleted"});
    }
}