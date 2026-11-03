using HotelBooking.Models;

namespace HotelBooking.Services
{
    public interface IBookingService
    {
        Task<List<Booking>> GetAllAsync();
        Task<Booking?> GetByIdAsync(int id);
        Task<Booking?> CreateAsync(Booking booking);
        Task<Booking?> UpdateAsync(int id, Booking booking);
        Task<Booking?> DeleteAsync(int id);
        Task<bool> IsRoomBusyAsync(int roomId, DateTime checkIn, DateTime checkOut, int exceptBookingId = 0);
        Task<bool> IsRoomExistsAsync(int roomId);
    }
}