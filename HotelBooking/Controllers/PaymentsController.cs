using HotelBooking.Services;
using Microsoft.AspNetCore.Mvc;
using HotelBooking.Models;
using HotelBooking.Dtos;

namespace HotelBooking.Controllers
{
    [ApiController]
    [Route("payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _paymentService.GetAllAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _paymentService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound(new { message = $"Payment {id} was not found" });
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentDto dto)
        {
            var payment = new Payment
            {
                Amount = dto.Amount,
                Status = dto.Status,
                BookingId = dto.BookingId,
            };
            var result = await _paymentService.CreateAsync(payment);
            if (result == null)
            {
                return NotFound(new { message = $"Booking {dto.BookingId} was not found" });
            }
            return Ok(result);
        }
        [HttpGet("booking/{bookingId:int}")]
        public async Task<IActionResult> GetByBookingId(int bookingId)
        {
            return Ok(await _paymentService.GetByBookingIdAsync(bookingId));
        }
    }
}
