using BackEnd.Data;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BackEnd.Services;

public class RoomServices
{
    private AppDbContext context;

    public RoomServices(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<List<Room>> GetAll()
    {
        return await this.context.Rooms.Include(r => r.Cinema).ThenInclude(c => c.Area).ToListAsync();
    } 

    public async Task<Room?> GetWithID(int id)
    {   
        return await this.context.Rooms.Include(r => r.Cinema).ThenInclude(c => c.Area).FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Room?> Add(Room room)
    {
        var existedRoom = await this.context.Rooms.FindAsync(room.Id);
        if (existedRoom is null)
            return null;

        room.Id = this.context.Rooms.Count() + 1;

        try
        {
            this.context.Rooms.Add(room);
            await this.context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "P0001")
                throw new Exception("Số lượng phòng của rạp đã đạt giới hạn.");
            throw;
        }    

        return room;
    }

    public async Task<bool> Delete(Guid id)
    {
        var room = await this.context.Rooms.FindAsync(id);
        if (room is null)
            return false;
        
        this.context.Rooms.Remove(room);
        await this.context.SaveChangesAsync();

        return true;
    }
}