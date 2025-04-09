using BackEnd.Services;
using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("/api/areas")]
public class AreaController: BaseController<Area>
{
    public AreaController(ILogger<AreaController> logger, AppDbContext context)
        : base(logger, new AreaServices(context))
    {
    }

    [HttpGet(Name = "GetAllAreas")]
    public new async Task<ActionResult<List<Area>>> GetAll()
    {
        return await base.GetAll();
    }

    [HttpGet("{id}", Name = "GetAreaWithId")]
    public new async Task<ActionResult<Area>> GetWithID(Guid id)
    {
        return await base.GetWithID(id);
    }

    [HttpPost(Name = "PostArea")]
    public new async Task<ActionResult<Area>> Post([FromBody] Area area)
    {
        return await base.Post(area);
    }

    [HttpDelete("{id}", Name = "DeleteArea")]
    public new async Task<ActionResult> Delete(Guid id)
    {
        return await base.Delete(id);
    }
}