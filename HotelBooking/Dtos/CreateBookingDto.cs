using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Dtos
{
    public class CreateBookingDto
    {
        [Required(ErrorMessage = "Name cannot be empty")]
        [StringLength(100)]
        public string? GuestName { get; set; }
        public DateTime CheckIn {  get; set; }
        public DateTime CheckOut { get; set; }
        [Required(ErrorMessage = "Payment method is required")]
        [StringLength(100)]
        public string? PaymentMethod { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "RoomId number must be greater than 0")]
        public int RoomId { get; set; }
    }
}
