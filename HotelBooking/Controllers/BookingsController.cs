using HotelBooking.Models;
using HotelBooking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace HotelBooking.Controllers
{
    [ApiController]
    [Route("bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookingService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _bookingService.GetByIdAsync(id);
            if(result == null)
            {
                return NotFound(new { message = $"Booking {id} was not found" });
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Booking booking)
        {
            return Ok(await _bookingService.CreateAsync(booking));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Booking booking)
        {
            var result = await _bookingService.UpdateAsync(id, booking);
            if (result == null)
            {
                return NotFound(new { message = $"Booking {id} was not found" });
            }
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookingService.DeleteAsync(id);
            if (result == null)
            {
                return NotFound(new { message = $"Booking {id} was not found" });
            }
            return Ok(result);
        }
    }
}