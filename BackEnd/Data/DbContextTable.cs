using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data;

public class DbContextTable
{
    public Dictionary<Type, object> ContextTable { get; private set; }

    public AppDbContext Context { get; }

    public DbContextTable(AppDbContext context)
    {
        this.Context = context;
        this.ContextTable = new Dictionary<Type, object>();

        // Lấy tất cả thuộc tính DbSet<> từ AppDbContext
        var dbSetProperties = typeof(AppDbContext).GetProperties()
            .Where(p => p.PropertyType.IsGenericType &&
                        p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

        foreach (var prop in dbSetProperties)
        {
            Type entityType = prop.PropertyType.GetGenericArguments()[0]; // Lấy kiểu T từ DbSet<T>
            object dbSet = prop.GetValue(context) ?? new object();
            
            if (dbSet != null)
            {
                ContextTable[entityType] = dbSet;
            }
        }
    }

    public DbSet<T> GetTable<T>() where T : class
    {
        if (ContextTable.TryGetValue(typeof(T), out var dbSet))
        {
            return (DbSet<T>)dbSet;
        }
        throw new InvalidOperationException($"Entity {typeof(T).Name} not found in ContextTable.");
    }
}