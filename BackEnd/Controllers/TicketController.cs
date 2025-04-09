using BackEnd.Data;
using BackEnd.Services;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/tickets")]
public class TicketController : ControllerBase
{
    protected readonly ILogger<TicketController> _logger;

    protected readonly TicketServices Services;

    public TicketController(ILogger<TicketController> logger, AppDbContext context)
    {
        this._logger = logger;
        this.Services = new TicketServices(context);
    }

    [HttpGet(Name = "GetAllTickets")]
    public async Task<ActionResult<List<Ticket>>> GetAll()
    {
        var tickets = await this.Services.GetAll();
        if (tickets is null)
            return NotFound("Not Found");

        return Ok(tickets);
    }

    [HttpGet("{id}", Name = "GetTicketWithId")]
    public async Task<ActionResult<Ticket>> GetWithID(Guid id)
    {
        var ticket = await this.Services.GetWithID(id);
        if (ticket is null)
            return NotFound();
        return Ok(ticket);
    }

    [HttpPost(Name = "PostTicket")]
    public async Task<ActionResult<Ticket>> Post([FromBody] Ticket ticket)
    {
        return Ok(await this.Services.Add(ticket));
    }

    [HttpDelete("{id}", Name = "DeleteTicket")]
    public async Task<ActionResult> Delete(Guid id)
    {
        bool isDeleted = await this.Services.Delete(id);
        if (!isDeleted)
            return NotFound();

        return Ok();
    }
}