using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Data;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("/api/genres")]
public class GenreController : BaseController<Genre>
{
    public GenreController(ILogger<GenreController> logger, AppDbContext context)
        : base(logger, new GenreServices(context))
    {
    }

    [HttpGet(Name = "GetAllGenres")]
    public new async Task<ActionResult<List<Genre>>> GetAll()
    {
        return await base.GetAll();
    }

    [HttpGet("{id}", Name = "GetGenreWithId")]
    public new async Task<ActionResult<Genre>> GetWithID(Guid id)
    {
        return await base.GetWithID(id);
    }

    [HttpPost(Name = "PostGenre")]
    public new async Task<ActionResult<Genre>> Post([FromBody] Genre genre)
    {
        return await base.Post(genre);
    }

    [HttpDelete("{id}", Name = "DeleteGenre")]
    public new async Task<ActionResult> Delete(Guid id)
    {
        return await base.Delete(id);
    }
}