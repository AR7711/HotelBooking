using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Dtos
{
    public class AuthDto
    {
        [Required(ErrorMessage = "Email can't be empty")]
        [EmailAddress(ErrorMessage = "This is not an email")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password can't be empty")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100")]
        public string Password { get; set; } = string.Empty;
    }
}
