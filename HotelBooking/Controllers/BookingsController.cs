using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace HotelBooking.Controllers
{
    [ApiController]
    [Route("bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly HotelContext _db;

        public BookingsController(HotelContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.bookings.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _db.bookings.FindAsync(id);
            if (result == null)
            {
                return NotFound(new { message = $"Booking {id} was not found" });
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Booking booking)
        {
            _db.bookings.Add(booking);
            await _db.SaveChangesAsync();
            return Ok(booking);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Booking booking)
        {
            var result = await _db.bookings.FindAsync(id);
            if (result == null)
            {
                return NotFound(new { message = $"Booking {id} was not found" });
            }
            result.GuestName = booking.GuestName;
            result.CheckIn = booking.CheckIn;
            result.CheckOut = booking.CheckOut;
            result.PaymentMethod = booking.PaymentMethod;
            result.RoomId = booking.RoomId;
            await _db.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _db.bookings.FindAsync(id);
            if (result == null)
            {
                return NotFound(new { message = $"Booking {id} was not found" });
            }
            _db.bookings.Remove(result);
            await _db.SaveChangesAsync();
            return Ok(result);
        }
    }
}
