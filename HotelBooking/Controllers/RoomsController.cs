using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace HotelBooking.Controllers
{
    [ApiController]
    [Route("rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly HotelContext _db;
        public RoomsController(HotelContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.rooms.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _db.rooms.FindAsync(id);
            if(result == null)
            {
                return NotFound(new {message = $"Room {id} was not found"});
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Room room)
        {
            _db.rooms.Add(room);
            await _db.SaveChangesAsync();
            return Ok(room);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Room room)
        {
            var result = await _db.rooms.FindAsync(id);
            if(result == null)
            {
                return NotFound(new { message = $"Room {id} was not found" });
            }
            result.Number = room.Number;
            result.Type = room.Type;
            result.Capacity = room.Capacity;
            result.Price = room.Price;
            await _db.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _db.rooms.FindAsync(id);
            if(result == null)
            {
                return NotFound(new { message = $"Room {id} was not found" });
            }
            _db.rooms.Remove(result);
            await _db.SaveChangesAsync();
            return Ok(result);
            
        }
    }
}
