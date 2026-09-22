using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string? Type { get; set; }
        public int Capacity { get; set; }
        [Column (TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking> ();
    }
}
