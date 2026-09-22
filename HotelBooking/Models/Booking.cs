namespace HotelBooking.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string? GuestName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string? PaymentMethod { get; set; }
        public int RoomId { get; set; }
        public Room? Room { get; set; }
    }
}
