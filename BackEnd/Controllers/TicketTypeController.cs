using BackEnd.Services;
using BackEnd.Data;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;

namespace BackEnd.Controllers;

[ApiController]
[Route("/api/ticket-types")]
public class TicketTypeController: BaseController<TicketType>
{
    public TicketTypeController(ILogger<TicketTypeController> logger, AppDbContext context)
        : base(logger, new TicketTypeServices(context))
    {
    }

    [HttpGet(Name = "GetAllTicketTypes")]
    public new async Task<ActionResult<List<TicketType>>> GetAll()
    {
        return await base.GetAll();
    }

    [HttpGet("{id}", Name = "GetTicketTypeWithId")]
    public new async Task<ActionResult<TicketType>> GetWithID(Guid id)
    {
        return await base.GetWithID(id);
    }

    [HttpPost(Name = "PostTicketType")]
    public new async Task<ActionResult<TicketType>> Post([FromBody] TicketType ticketType)
    {
        return await base.Post(ticketType);
    }

    [HttpDelete("{id}", Name = "DeleteTicketType")]
    public new async Task<ActionResult> Delete(Guid id)
    {
        return await base.Delete(id);
    }
}