using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [Column (TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }
        public PaymentStatus Status { get; set; }
        public int BookingId { get; set; }
        public Booking? Booking { get; set; }
    }
}