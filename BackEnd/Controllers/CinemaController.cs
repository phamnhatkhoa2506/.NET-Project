using BackEnd.Data;
using BackEnd.Services;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/cinemas")]
public class CinemaController : ControllerBase
{
    private readonly ILogger<CinemaController> _logger;

    private readonly CinemaServices Services;

    public CinemaController(ILogger<CinemaController> logger, AppDbContext context)
    {
        this._logger = logger;
        this.Services = new CinemaServices(context);
    }

    [HttpGet(Name = "GetAllCinemas")]
    public async Task<ActionResult<List<Cinema>>> GetAll()
    {
        var cinemas = await this.Services.GetAll();
        if (cinemas == null)
            return NotFound();

        return Ok(cinemas);
    }

    [HttpGet("{id}", Name = "GetCinemaWithId")]
    public async Task<ActionResult<Cinema>> GetWithID(Guid id)
    {
        Cinema? cinema = await this.Services.GetWithID(id);
        if (cinema == null)
            return NotFound();
        return Ok(cinema);
    }

    [HttpPost(Name = "PostCinema")]
    public async Task<ActionResult<Cinema>> Post([FromBody] Cinema cinema)
    {
        var newCinema = await this.Services.Add(cinema);
        return newCinema is not null 
               ? Ok(newCinema) 
               : new ConflictObjectResult("Cinema already exist");
    }

    [HttpDelete("{id}", Name = "DeleteCinema")]
    public async Task<ActionResult> Delete(Guid id)
    {
        bool isDeleted = await this.Services.Delete(id);
        return  isDeleted 
                ? Ok(new {message = String.Format("Cinema with ID {0} deleted successfully", id)})
                : NotFound(String.Format("Cinema with ID {0} is not existed", id));
    }
}