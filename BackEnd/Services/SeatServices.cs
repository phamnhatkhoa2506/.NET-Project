using BackEnd.Data;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services;

public class SeatServices
{
    private AppDbContext context;

    public SeatServices(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<List<Seat>> GetAll()
    {
        return await this.context.Seats.Include(s => s.SeatType).ToListAsync();
    } 

    public async Task<Seat?> GetWithID(Guid id)
    {
        return await this.context.Seats.Include(s => s.SeatType).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Seat?> Add(Seat seat)
    {
        var existedSeat = await this.context.Seats.FindAsync(seat.Id);
        if (existedSeat is null)
            return null;

        seat.Id = Guid.NewGuid();

        this.context.Seats.Add(seat);
        await this.context.SaveChangesAsync();

        return seat;
    }

    public async Task<bool> Delete(Guid id)
    {
        var seat = await this.context.Seats.FindAsync(id);
        if (seat is null)
            return false;
        
        this.context.Seats.Remove(seat);
        await this.context.SaveChangesAsync();

        return true;
    }
}