using BackEnd.Data;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BackEnd.Services;

public class ShowtimeServices
{
    private AppDbContext context;

    public ShowtimeServices(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<List<Showtime>> GetAll()
    {
        return await this.context.Showtimes
                        .Include(s => s.Movie)
                        .Include(s => s.Room)
                            .ThenInclude(r => r.Cinema)
                                .ThenInclude(c => c.Area)
                        .ToListAsync();
    }

    public async Task<List<Showtime>> GetShowtimesWithDate(DateOnly date)
    {
        return await this.context.Showtimes
                        .Include(s => s.Movie)
                        .Include(s => s.Room)
                        .Where(s => s.DateShow == date)
                        .ToListAsync();
    }

    public async Task<List<Showtime>> GetShowtimesWithTime(TimeOnly time)
    {
        return await this.context.Showtimes
                        .Include(s => s.Movie)
                        .Include(s => s.Room)
                        .Where(s => s.StartTime == time)
                        .ToListAsync();
    }

    public async Task<Showtime?> GetShowtimeWithDateTime(DateOnly date, TimeOnly time)
    {
        return await this.context.Showtimes
                        .Include(s => s.Movie)
                        .Include(s => s.Room)
                        .FirstOrDefaultAsync(s => s.DateShow == date && s.StartTime == time);
    }

    public async Task<Showtime?> GetShowtimeWithID(Guid id)
    {
        return await this.context.Showtimes
                        .Include(s => s.Movie)
                        .Include(s => s.Room)
                        .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Showtime?> Add(Showtime showtime)
    {
        try
        {
            showtime.Id = Guid.NewGuid();

            if (showtime.Movie is not null)
            {
                showtime.MovieId = showtime.Movie.Id;
                this.context.Attach(showtime.Movie);
            }
            if (showtime.Room is not null)
            {
                showtime.RoomId = showtime.Room.Id;
                this.context.Attach(showtime.Room);
            }

            await this.context.Showtimes.AddAsync(showtime);
            await this.context.SaveChangesAsync();

            return showtime;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    public async Task<bool> Delete(Guid id)
    {
        try
        {
            var showtime = await this.context.Showtimes.FindAsync(id);
            if (showtime is null)
                return false;

            this.context.Showtimes.Remove(showtime);
            await this.context.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}