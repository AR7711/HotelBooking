using HotelBooking.Models;
using System.Text.Json.Serialization;
namespace HotelBooking.Services
{
    public interface IAuthService
    {
        Task<bool> IsEmailExistsAsync(string email);
        Task<User> RegisterAsync(string email, string password);
    }
}
