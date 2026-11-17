using HotelBooking.Models;

namespace HotelBooking.Services
{
    public interface IAuthService
    {
        Task<bool> IsEmailTakenAsync(string email);
        Task<User> RegisterAsync(string email, string password);
    }
}
