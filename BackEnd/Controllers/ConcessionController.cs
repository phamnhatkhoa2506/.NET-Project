using BackEnd.Services;
using BackEnd.Data;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;

namespace BackEnd.Controllers;

[ApiController]
[Route("/api/concessions")]
public class ConcessionController: ControllerBase
{
    private readonly ILogger<ConcessionController> _logger;

    private readonly ConcessionServices Services;

    public ConcessionController(ILogger<ConcessionController> logger, AppDbContext context)
    {
        _logger = logger;
        Services = new ConcessionServices(context);
    }

    [HttpGet(Name = "GetAllConcessions")]
    public async Task<ActionResult<List<Concession>>> GetAll()
    {
        var concessions = await this.Services.GetAll();
        if (concessions == null)
            return NotFound("Cannot get all concession");

        return Ok(concessions);
    }

    [HttpGet("{id}", Name = "GetConcessionWithId")]
    public async Task<ActionResult<Concession>> GetWithID(Guid id)
    {
        Concession? concession = await this.Services.GetWithID(id);
        if (concession == null)
            return NotFound(String.Format("Cannot find the concession with id: {0}", id));
        return Ok(concession);
    }

    [HttpPost(Name = "PostConcession")]
    public async Task<ActionResult<Concession>> Post([FromBody] Concession concession)
    {
        var newConcession = await this.Services.Add(concession);
        return newConcession is not null 
               ? Ok(newConcession) 
               : new ConflictObjectResult("Concession already exist");
    }

    [HttpDelete("{id}", Name = "Deleteconcession")]
    public async Task<ActionResult> Delete(Guid id)
    {
        bool isDeleted = await this.Services.Delete(id);
        return  isDeleted 
                ? Ok(new {message = String.Format("Concession with ID {0} deleted successfully", id)})
                : NotFound(String.Format("Concession with ID {0} is not existed", id));
    }
}