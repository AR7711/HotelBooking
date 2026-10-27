using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }
        public DbSet<Room> rooms { get; set; } = null!;
        public DbSet<Booking> bookings { get; set; } = null!;
        public DbSet<Payment> payments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>()            
                .HasOne(b => b.Room)                  
                .WithMany(r => r.Bookings)            
                .HasForeignKey(b => b.RoomId)         
                .OnDelete(DeleteBehavior.Restrict);   
        }
    }
}