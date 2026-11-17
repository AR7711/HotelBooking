using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Email can't be empty")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password can't be empty")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100")]
        public string Password { get; set; } = string.Empty;
    }
}
