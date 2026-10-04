using HotelBooking.Models;
using HotelBooking.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    [ApiController]
    [Route("rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly RoomService _roomService;

        public RoomsController(RoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roomService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _roomService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound(new { message = $"Room {id} was not found" });
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Room room)
        {
            return Ok(await _roomService.CreateAsync(room));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Room room)
        {
            var result = await _roomService.UpdateAsync(id, room);
            if (result == null)
            {
                return NotFound(new { message = $"Room {id} was not found" });
            }
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _roomService.DeleteAsync(id);
            if (result == null)
            {
                return NotFound(new { message = $"Room {id} was not found" });
            }
            return Ok(result);
        }
    }
}