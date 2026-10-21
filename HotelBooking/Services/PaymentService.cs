using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;
namespace HotelBooking.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly HotelContext _db;
        public PaymentService(HotelContext db)
        {
            _db = db;
        }
        public async Task<List<Payment>> GetAllAsync()
        {
            return await _db.payments.ToListAsync();
        }
        public async Task<Payment?> GetByIdAsync(int id)
        {
            return await _db.payments.FindAsync(id);
        }
        public async Task<Payment?> CreateAsync(Payment payment)
        {
            bool bookingExists = await _db.bookings.AnyAsync(b => b.Id == payment.BookingId);
            if (!bookingExists)
            {
                return null;
            }
            payment.PaidAt = DateTime.Now;
            _db.payments.Add(payment);
            await _db.SaveChangesAsync();
            return payment;
        }
        public async Task<List<Payment>> GetByBookingIdAsync(int bookingId)
        {
            return await _db.payments.Where(b => b.BookingId == bookingId).ToListAsync();
        }
    }
}
