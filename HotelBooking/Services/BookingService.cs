using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Services
{
    public class BookingService : IBookingService
    {
        private readonly HotelContext _db;
        public BookingService(HotelContext db)
        {
            _db = db;
        }
        public async Task<List<Booking>> GetAllAsync()
        {
            return await _db.bookings.ToListAsync();
        }
        public async Task<Booking?> GetByIdAsync(int id)
        {
            return await _db.bookings.FindAsync(id);
        }
        public async Task<Booking> CreateAsync(Booking booking)
        {
            _db.bookings.Add(booking);
            await _db.SaveChangesAsync();
            return booking;
        }
        public async Task<Booking?> UpdateAsync(int id, Booking booking)
        {
            var result = await _db.bookings.FindAsync(id);
            if(result == null)
            {
                return null;
            }
            result.GuestName = booking.GuestName;
            result.CheckIn = booking.CheckIn;
            result.CheckOut = booking.CheckOut;
            result.PaymentMethod = booking.PaymentMethod;
            await _db.SaveChangesAsync();
            return result;
        }
        public async Task<Booking?> DeleteAsync(int id)
        {
            var result = await _db.bookings.FindAsync(id);
            if(result == null)
            {
                return null;
            }
            _db.bookings.Remove(result);
            await _db.SaveChangesAsync();
            return result;
        }
    }
}
