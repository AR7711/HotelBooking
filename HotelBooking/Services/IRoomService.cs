using HotelBooking.Models;

namespace HotelBooking.Services
{
    public interface IRoomService
    {
        Task<List<Room>> GetAllAsync();
        Task<Room?> GetByIdAsync(int id);
        Task<Room> CreateAsync(Room room);
        Task<Room?> UpdateAsync(int id, Room room);
        Task<Room?> DeleteAsync(int id);
    }
}
