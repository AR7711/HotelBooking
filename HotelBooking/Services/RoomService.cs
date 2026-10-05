using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Services
{
    public class RoomService : IRoomService
    {
        private readonly HotelContext _db;
        public RoomService(HotelContext db)
        {
            _db = db;
        }
        public async Task<List<Room>> GetAllAsync()
        {
            return await _db.rooms.ToListAsync();
        }
        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _db.rooms.FindAsync(id);
        }
        public async Task<Room> CreateAsync(Room room)
        {
            _db.rooms.Add(room);
            await _db.SaveChangesAsync();
            return room;
        }
        public async Task<Room?> UpdateAsync(int id, Room room)
        {
            var result = await _db.rooms.FindAsync(id);
            if(result == null)
            {
                return null;
            }
            result.Number = room.Number;
            result.Type = room.Type;
            result.Capacity = room.Capacity;
            result.Price = room.Price;
            await _db.SaveChangesAsync();
            return result;
        }
        public async Task<Room?> DeleteAsync(int id)
        {
            var result = await _db.rooms.FindAsync(id);
            if(result == null)
            {
                return null;
            }
            _db.rooms.Remove(result);
            await _db.SaveChangesAsync();
            return result;
        }
    }
}