using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Data;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("/api/limitages")]
public class LimitAgeController: BaseController<LimitAge>
{
    public LimitAgeController(ILogger<LimitAgeController> logger, AppDbContext context)
        : base(logger, new LimitAgeServices(context))
    {
    }

    [HttpGet(Name = "GetAllLimitAges")]
    public new async Task<ActionResult<List<LimitAge>>> GetAll()
    {
        return await base.GetAll();
    }

    [HttpGet("{id}", Name = "GetLimitAgeWithId")]
    public new async Task<ActionResult<LimitAge>> GetWithID(Guid id)
    {
        return await base.GetWithID(id);
    }

    [HttpPost(Name = "PostLimitAge")]
    public new async Task<ActionResult<LimitAge>> Post([FromBody] LimitAge limitAge)
    {
        return await base.Post(limitAge);
    }

    [HttpDelete("{id}", Name = "DeleteLimitAge")]
    public new async Task<ActionResult> Delete(Guid id)
    {
        return await base.Delete(id);
    }
}