using HotelBooking.Models;

namespace HotelBooking.Services
{
    public interface IBookingService
    {
        Task<List<Booking>> GetAllAsync();
        Task<Booking?> GetByIdAsync(int id);
        Task<Booking> CreateAsync(Booking booking);
        Task<Booking?> UpdateAsync(int id, Booking booking);
        Task<Booking?> DeleteAsync(int id);
    }
}
