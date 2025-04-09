using BackEnd.Data;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services;

public class BaseServices<T> 
    where T: NameBase
{
    protected string entityName;

    protected DbContextTable contextTable;

    public BaseServices(string entityName, AppDbContext context)
    {
        this.entityName = entityName;
        this.contextTable = new DbContextTable(context);
    }

    public virtual async Task<List<T>> GetAll()
    {
        var queryable = this.contextTable.GetTable<T>();
    
        return await queryable.ToListAsync();
    }


    public virtual async Task<T?> GetWithID(Guid id)
    {
        var queryable = this.contextTable.GetTable<T>();
        
        return await queryable.FindAsync(id);
    }

    public virtual async Task<T?> Add(T entity)
    {
        var queryable = this.contextTable.GetTable<T>();

        bool existed = await queryable.AnyAsync(
            e => e.NameVn == entity.NameVn || 
                 e.NameEn == entity.NameEn
        );

        if (existed) return null;

        entity.Id = Guid.NewGuid();

        queryable.Add(entity);
        await this.contextTable.Context.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> Delete(Guid id)
    {
        var queryable = this.contextTable.GetTable<T>();

        var entity = await queryable.FindAsync(id);
        if (entity == null) 
            return false;
        queryable.Remove(entity);

        return true;
    }
}

public class AreaServices : BaseServices<Area>
{
    public AreaServices(AppDbContext context) : base("Areas", context)
    {
    }
}

public class ConcessionTypeServices : BaseServices<ConcessionType>
{
    public ConcessionTypeServices(AppDbContext context) : base("ConcessionTypes", context)
    {
    }
}

public class CountryServices : BaseServices<Country>
{
    public CountryServices(AppDbContext context) : base("Countries", context)
    {
    }
}

public class FormatServices : BaseServices<Format>
{
    public FormatServices(AppDbContext context) : base("Formats", context)
    {
    }
}

public class GenreServices : BaseServices<Genre>
{
    public GenreServices(AppDbContext context) : base("Genres", context)
    {
    }
}

public class LanguageServices : BaseServices<Language>
{
    public LanguageServices(AppDbContext context) : base("Languages", context)
    {
    }
}

public class LimitAgeServices : BaseServices<LimitAge>
{
    public LimitAgeServices(AppDbContext context) : base("LimitAges", context)
    {
    }
}

public class SeatTypeServices : BaseServices<SeatType>
{
    public SeatTypeServices(AppDbContext context) : base("SeatTypes", context)
    {
    }
}

public class TicketTypeServices : BaseServices<TicketType>
{
    public TicketTypeServices(AppDbContext context) : base("TicketTypes", context)
    {
    }
}