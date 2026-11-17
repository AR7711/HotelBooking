using System.Text.Json.Serialization;

namespace HotelBooking.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        [JsonIgnore]
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }
}
