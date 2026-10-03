using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        public DbSet<Room> rooms { get; set; } = null!;
        public DbSet<Booking> bookings { get; set; } = null!;
    }
}