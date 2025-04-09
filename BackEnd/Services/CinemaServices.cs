using BackEnd.Data;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services;

public class CinemaServices
{
    private AppDbContext context;

    public CinemaServices(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<List<Cinema>> GetAll()
    {
        return await this.context.Cinemas.Include(t => t.Area).ToListAsync();
    } 

    public async Task<Cinema?> GetWithID(Guid id)
    {
        return await this.context.Cinemas
                .Include(t => t.Area)
                .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Cinema?> Add(Cinema cinema)
    {
        var existedCinemaName = await this.context.Cinemas
                                      .FirstOrDefaultAsync(c => c.NameVn.ToLower() == cinema.NameVn.ToLower() ||
                                                                c.NameEn.ToLower() == cinema.NameEn.ToLower());
        var existedCinemaAddress = await this.context.Cinemas
                                        .FirstOrDefaultAsync(c => c.Address.ToLower() == cinema.Address.ToLower());
                                                                
        if (existedCinemaName is not null || existedCinemaAddress is not null)
            return null;

        cinema.Id = Guid.NewGuid();

        if (cinema.Area is not null)
        {
            cinema.AreaId = cinema.Area.Id;
            cinema.Area = null;
        }

        await this.context.Cinemas.AddAsync(cinema);
        await this.context.SaveChangesAsync();

        return cinema;
    }

    public async Task<bool> Delete(Guid id)
    {
        var cinema = await this.context.Cinemas.FindAsync(id);
        if (cinema is null)
            return false;
        
        this.context.Cinemas.Remove(cinema);
        await this.context.SaveChangesAsync();

        return true;
    }
}