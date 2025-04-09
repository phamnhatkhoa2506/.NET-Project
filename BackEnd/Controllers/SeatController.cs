using BackEnd.Data;
using BackEnd.Services;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/seats")]
public class SeatController : ControllerBase
{
    public readonly ILogger<SeatController> _logger;

    public readonly SeatServices Services;

    public SeatController(ILogger<SeatController> logger, AppDbContext context)
    {
        this._logger = logger;
        this.Services = new SeatServices(context);
    }

    [HttpGet(Name = "GetAllSeats")]
    public async Task<ActionResult<List<Seat>>> GetAll()
    {
        var seats = await this.Services.GetAll();
        if (seats is null)
            return NotFound("Not Found");

        return Ok(seats);
    }

    [HttpGet("{id}", Name = "GetSeatWithId")]
    public async Task<ActionResult<Seat>> GetWithID(Guid id)
    {
        var seat = await this.Services.GetWithID(id);
        if (seat is null)
            return NotFound();
        return Ok(seat);
    }

    [HttpPost(Name = "PostSeat")]
    public async Task<ActionResult<Seat>> Post([FromBody] Seat seat)
    {
        var newSeat = await this.Services.Add(seat);
        if (newSeat is null)
            return new ConflictObjectResult("Already exist");

        return Ok(newSeat);
    }

    [HttpDelete("{id}", Name = "DeleteSeat")]
    public async Task<ActionResult> Delete(Guid id)
    {
        bool isDeleted = await this.Services.Delete(id);
        if (!isDeleted)
            return NotFound();

        return Ok();
    }
}