using HotelBooking.Dtos;
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
        public async Task<IActionResult> Create(CreateBookingDto dto)
        {
            if(dto.CheckIn >= dto.CheckOut)
            {
                return BadRequest(new { message = "CheckOut must be after CheckIn" });
            }
            if(dto.CheckIn < DateTime.Today)
            {
                return BadRequest(new { message = "You can't book for previous dates" });
            }
            if(await _bookingService.IsRoomBusyAsync(dto.RoomId, dto.CheckIn, dto.CheckOut))
            {
                return Conflict(new {message = $"Room {dto.RoomId} is already booked for these dates" });
            }
            TimeSpan minus = dto.CheckOut - dto.CheckIn;
            int newMinus = minus.Days;
            if(newMinus > 30)
            {
                return BadRequest(new { message = "Booking cannot be longer than 30 nights" });
            }
            var booking = new Booking
            {
                GuestName = dto.GuestName,
                CheckIn = dto.CheckIn,
                CheckOut = dto.CheckOut,
                RoomId = dto.RoomId
            };
            var result = await _bookingService.CreateAsync(booking);
            if(result == null)
            {
                return NotFound(new { message = $"Room {dto.RoomId} was not found" });
            }
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CreateBookingDto dto)
        {
            if(!await _bookingService.IsRoomExistsAsync(dto.RoomId))
            {
                return NotFound(new { message = "Room was not found" });
            }
            if (dto.CheckIn >= dto.CheckOut)
            {
                return BadRequest(new { message = "CheckOut must be after CheckIn" });
            }
            if (dto.CheckIn < DateTime.Today)
            {
                return BadRequest(new { message = "You can't book for previous dates" });
            }
            if (await _bookingService.IsRoomBusyAsync(dto.RoomId, dto.CheckIn, dto.CheckOut, id))
            {
                return Conflict(new { message = $"Room {dto.RoomId} is already booked for these dates" });
            }
            TimeSpan wait = dto.CheckOut - dto.CheckIn;
            int newWait = wait.Days;
            if(newWait > 30)
            {
                return BadRequest(new { message = "Booking cannot be longer than 30 nights" });
            }
            var booking = new Booking
            {
                GuestName = dto.GuestName,
                CheckIn = dto.CheckIn,
                CheckOut = dto.CheckOut,
                RoomId = dto.RoomId
            };           var result = await _bookingService.UpdateAsync(id, booking);
            if (result == null)
            {
                return NotFound(new { message = $"Booking {id} was not found" });
            }
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var secRes = await _bookingService.IsPaymentExistsAsync(id);
            if (secRes)
            {
                return Conflict(new { message = $"Booking {id} has payments and cannot be deleted" });
            }
            var result = await _bookingService.DeleteAsync(id);
            if (result == null)
            {
                return NotFound(new { message = $"Booking {id} was not found" });
            }
            return Ok(result);
        }
    }
}