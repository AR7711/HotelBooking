using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Services
{
    public class AuthService : IAuthService
    {
        private readonly HotelContext _db;
        public AuthService(HotelContext db)
        {
            _db = db;
        }
        public async Task<bool> IsEmailExistsAsync(string email)
        {
            var result = await _db.users.AnyAsync(u => u.Email == email);
            return result;
        }
        public async Task<User> RegisterAsync(string email, string password)
        {
            var user = new User
            {
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                Role = UserRole.User
            };
            _db.users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }
}
