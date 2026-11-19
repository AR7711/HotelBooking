using HotelBooking.Dtos;
using HotelBooking.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthDto dto)
        {
            var result = await _authService.IsEmailExistsAsync(dto.Email);
            if (result)
            {
                return Conflict(new { message = "This Email address already exists" });
            }
            var user = await _authService.RegisterAsync(dto.Email, dto.Password);
            return Ok(user);
        }
    }
}
