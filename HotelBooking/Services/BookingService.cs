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
        public async Task<Booking?> CreateAsync(Booking booking)
        {
            bool result = await _db.bookings.AnyAsync(b => b.Id == b.RoomId);
            if(!result)
            {
                return null;
            }
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
        public async Task<bool> IsRoomBusyAsync(int roomId, DateTime checkIn, DateTime checkOut)
        {
            var result = await _db.bookings.AnyAsync(b => b.RoomId == roomId &&
            b.CheckIn < checkIn && b.CheckOut < checkOut);
            return result;
        }
    }
}
