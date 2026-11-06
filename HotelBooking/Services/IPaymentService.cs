using HotelBooking.Models;

namespace HotelBooking.Services
{
    public interface IPaymentService
    {
        Task<List<Payment>> GetAllAsync();
        Task<Payment?> GetByIdAsync(int id);
        Task<Payment?> CreateAsync(Payment payment);
        Task<List<Payment>> GetByBookingIdAsync(int bookingId);
        Task<decimal?> GetBookingTotalAsync(int bookingId);
        Task<bool> IsBookingHavePaymentAsync(int bookingId);
    }
}
