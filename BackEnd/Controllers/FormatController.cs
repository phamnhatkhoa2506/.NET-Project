using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Data;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("/api/formats")]
public class FormatController: BaseController<Format>
{
    public FormatController(ILogger<FormatController> logger, AppDbContext context)
        : base(logger, new FormatServices(context))
    {
    }

    [HttpGet(Name = "GetAllFormats")]
    public new async Task<ActionResult<List<Format>>> GetAll()
    {
        return await base.GetAll();
    }

    [HttpGet("{id}", Name = "GetFormatWithId")]
    public new async Task<ActionResult<Format>> GetWithID(Guid id)
    {
        return await base.GetWithID(id);
    }

    [HttpPost(Name = "PostFormat")]
    public new async Task<ActionResult<Format>> Post([FromBody] Format format)
    {
        return await base.Post(format);
    }

    [HttpDelete("{id}", Name = "DeleteFormat")]
    public new async Task<ActionResult> Delete(Guid id)
    {
        return await base.Delete(id);
    }
}