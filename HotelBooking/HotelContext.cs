using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Models
{
    public class HotelContext : DbContext
    {
        public DbSet<Room> rooms { get; set; } = null!;
        public DbSet<Booking> bookings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string stringConnect = "server=localhost;user=*******;password=********;database=hotelbooking";
            optionsBuilder.UseMySql(stringConnect, ServerVersion.AutoDetect(stringConnect));
        }
    }
}
