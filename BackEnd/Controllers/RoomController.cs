using BackEnd.Data;
using BackEnd.Services;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/rooms")]
public class RoomController : ControllerBase
{
    public readonly ILogger<RoomController> _logger;

    public readonly RoomServices Services;

    public RoomController(ILogger<RoomController> logger, AppDbContext context)
    {
        this._logger = logger;
        this.Services = new RoomServices(context);
    }

    [HttpGet(Name = "GetAllRooms")]
    public async Task<ActionResult<List<Room>>> GetAll()
    {
        var rooms = await this.Services.GetAll();
        if (rooms is null)
            return NotFound("Not Found");

        return Ok(rooms);
    }

    [HttpGet("{id}", Name = "GetRoomWithId")]
    public async Task<ActionResult<Room>> GetWithID(int id)
    {
        var room = await this.Services.GetWithID(id);
        if (room is null)
            return NotFound();
        return Ok(room);
    }

    [HttpPost(Name = "PostRoom")]
    public async Task<ActionResult<Room>> Post([FromBody] Room room)
    {
        try
        {
            var newRoom = await this.Services.Add(room);
            if (newRoom is null)
                return new ConflictObjectResult("Already exist");

            return Ok(newRoom);
        }
        catch (Exception ex)
        {
            return BadRequest(new {error = ex.Message});
        }
        
    }

    [HttpDelete("{id}", Name = "DeleteRoom")]
    public async Task<ActionResult> Delete(Guid id)
    {
        bool isDeleted = await this.Services.Delete(id);
        if (!isDeleted)
            return NotFound();

        return Ok();
    }
}