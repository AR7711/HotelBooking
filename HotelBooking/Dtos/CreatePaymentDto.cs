using System.ComponentModel.DataAnnotations;
using HotelBooking.Models;

namespace HotelBooking.Dtos
{
    public class CreatePaymentDto
    {
        [Range(0.01, 100000, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }
        [EnumDataType(typeof(PaymentStatus), ErrorMessage = "Status must be Paid, Failed or Refunded")]
        public PaymentStatus Status { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public int BookingId { get; set; }

    }
}
