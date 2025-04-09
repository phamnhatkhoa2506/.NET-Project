using BackEnd.Services;
using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("/api/concession-types")]
public class ConcessionTypeController: BaseController<ConcessionType>
{
    public ConcessionTypeController(ILogger<ConcessionTypeController> logger, AppDbContext context)
        : base(logger, new ConcessionTypeServices(context))
    {
    }

    [HttpGet(Name = "GetAllConcessionTypes")]
    public new async Task<ActionResult<List<ConcessionType>>> GetAll()
    {
        return await base.GetAll();
    }

    [HttpGet("{id}", Name = "GetConcessionTypeWithId")]
    public new async Task<ActionResult<ConcessionType>> GetWithID(Guid id)
    {
        return await base.GetWithID(id);
    }

    [HttpPost(Name = "PostConcessionType")]
    public new async Task<ActionResult<ConcessionType>> Post([FromBody] ConcessionType concessionType)
    {
        return await base.Post(concessionType);
    }

    [HttpDelete("{id}", Name = "DeleteConcessionType")]
    public new async Task<ActionResult> Delete(Guid id)
    {
        return await base.Delete(id);
    }
}