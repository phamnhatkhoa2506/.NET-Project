using BackEnd.Data;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services;

public class TicketServices 
{
    private AppDbContext context;

    public TicketServices(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<List<Ticket>> GetAll()
    {
        return await this.context.Tickets.Include(t => t.TicketType).ToListAsync();
    } 

    public async Task<Ticket?> GetWithID(Guid id)
    {        
        return await this.context.Tickets
                     .Include(t => t.TicketType)
                     .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Ticket?> Add(Ticket ticket)
    {
        ticket.Id = Guid.NewGuid();

        if (ticket.TicketType is not null)
        {
            ticket.TicketTypeId = ticket.TicketType.Id;
            ticket.TicketType = null;
        }

        this.context.Tickets.Add(ticket);
        await this.context.SaveChangesAsync();

        return ticket;
    }

    public async Task<bool> Delete(Guid id)
    {
        var ticket = await this.context.Tickets.FindAsync(id);
        if (ticket is null)
            return false;
        
        this.context.Tickets.Remove(ticket);

        return true;
    }
}