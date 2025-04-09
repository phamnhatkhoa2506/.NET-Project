using BackEnd.Data;
using BackEnd.Services;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/showtimes")]
public class ShowtimeController : ControllerBase
{
    public readonly ILogger<ShowtimeController> _logger;

    public readonly ShowtimeServices Services;

    public ShowtimeController(ILogger<ShowtimeController> logger, AppDbContext context)
    {
        this._logger = logger;
        this.Services = new ShowtimeServices(context);
    }

    [HttpGet("all", Name = "GetAllShowtimes")]
    public async Task<ActionResult<List<Showtime>>> GetAll()
    {
        var showtimes = await this.Services.GetAll();
    
        return Ok(showtimes);
    }

    [HttpGet("date", Name = "GetShowtimesWithDate")]
    public async Task<ActionResult<List<Showtime>>> GetShowtimesWithDate([FromQuery] DateOnly date)
    {
        var showtimesWithDate = await this.Services.GetShowtimesWithDate(date);
        return Ok(showtimesWithDate);
    }

    [HttpGet("time", Name = "GetShowtimesWithTime")]
    public async Task<ActionResult<List<Showtime>>> GetShowtimesWithTime([FromQuery] TimeOnly time)
    {
        var showtimesWithTime = await this.Services.GetShowtimesWithTime(time);
        return Ok(showtimesWithTime);
    }

    [HttpGet("datetime", Name = "GetShowtimesWithDateTime")]
    public async Task<ActionResult<List<Showtime>>> GetShowtimesWithTime(
        [FromQuery] DateOnly date, [FromQuery] TimeOnly time
    )
    {
        var showtimeWithDateTime = await this.Services.GetShowtimeWithDateTime(date, time);
        if (showtimeWithDateTime is null)
            return NotFound("Showtime with date = " + date.ToString() + "and time = " + time.ToString() + " has not been found");
        return Ok(showtimeWithDateTime);
    }

    [HttpGet("{id}", Name = "GetShowtimeWithID")]
    public async Task<ActionResult<Showtime>> GetShowtimeWithID(Guid id)
    {
        var showtime = await this.Services.GetShowtimeWithID(id);
        if (showtime is null)
            return NotFound("Showtime with ID " + id.ToString() + " has not been found");
        return Ok(showtime);
    }

    [HttpPost(Name = "PostShowtime")]
    public async Task<ActionResult<Showtime>> PostShowtime([FromBody] Showtime showtime)
    {
        try
        {
            var newShowtime = await this.Services.Add(showtime);
            if (newShowtime is null)
                return new ConflictObjectResult("Conflict show time");

            return Ok(newShowtime);
        }
        catch (Exception e)
        {
            return BadRequest(new {error = e.Message});
        }
    }

    [HttpDelete("{id}", Name = "DeleteShowtimeWithID")]
    public async Task<ActionResult> DeleteWithID(Guid id)
    {
        bool isDeleted = await this.Services.Delete(id);
        if (!isDeleted)
            return NotFound();

        return NoContent();
    }
}