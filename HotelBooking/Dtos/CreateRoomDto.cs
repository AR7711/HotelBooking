using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Dtos
{
    public class CreateRoomDto
    {
        [Range(1, 9999, ErrorMessage = "Number must be greater than 0")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Type is required")]
        [StringLength(100)]
        public string? Type { get; set; }
        [Range(1, 10, ErrorMessage = "Capacity must be between 1 -10")]
        public int Capacity { get; set; }
        [Range(0.01, int.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
    }
}
