using BackEnd.Models;
using BackEnd.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services;

public class ConcessionServices
{
    private AppDbContext context;

    public ConcessionServices(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<List<Concession>> GetAll()
    {
        return await this.context.Concessions.Include(c => c.ConcessionType).ToListAsync();
    } 

    public async Task<Concession?> GetWithID(Guid id)
    {
        return await this.context.Concessions
                     .Include(c => c.ConcessionType)
                     .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Concession?> Add(Concession concession)
    {
        var existedConcession = await this.context.Concessions
                                    .FirstOrDefaultAsync(c => c.NameVn == concession.NameVn ||
                                                              c.NameEn == concession.NameEn);
        if (existedConcession is not null)  
            return null;
                                        
        concession.Id = Guid.NewGuid();
        if (concession.ConcessionType is not null)
        {
            concession.ConcessionTypeId = concession.ConcessionType.Id;
            concession.ConcessionType = null;
        }

        this.context.Concessions.Add(concession);
        await this.context.SaveChangesAsync();

        return concession;
    }

    public async Task<bool> Delete(Guid id)
    {
        var concession = await this.context.Concessions.FindAsync(id);
        if (concession is null)
            return false;
        
        this.context.Concessions.Remove(concession);

        return true;
    }
}