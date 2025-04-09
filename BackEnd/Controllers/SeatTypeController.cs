using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Data;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("/api/seat-types")]
public class SeatTypeController: BaseController<SeatType>
{
    public SeatTypeController(ILogger<SeatTypeController> logger, AppDbContext context)
        : base(logger, new SeatTypeServices(context))
    {
    }

    [HttpGet(Name = "GetAllSeatTypes")]
    public new async Task<ActionResult<List<SeatType>>> GetAll()
    {
        return await base.GetAll();
    }

    [HttpGet("{id}", Name = "GetSeatTypeWithId")]
    public new async Task<ActionResult<SeatType>> GetWithID(Guid id)
    {
        return await base.GetWithID(id);
    }

    [HttpPost(Name = "PostSeatType")]
    public new async Task<ActionResult<SeatType>> Post([FromBody] SeatType seatType)
    {
        return await base.Post(seatType);
    }

    [HttpDelete("{id}", Name = "DeleteSeatType")]
    public new async Task<ActionResult> Delete(Guid id)
    {
        return await base.Delete(id);
    }
}