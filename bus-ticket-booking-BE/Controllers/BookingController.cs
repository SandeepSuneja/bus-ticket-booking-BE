using bus_ticket_booking_BE.Data;
using bus_ticket_booking_BE.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bus_ticket_booking_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : Controller
    {
        private ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetBookings()
        {
            return _context.Bookings.ToList();
        }

        [HttpPost]
        public async Task<ActionResult> AddBooking()
        {
            Booking booking = new Booking();
            booking.booking_id = 403;
            booking.bus_id = 101;
            booking.route_id = 201;
            booking.schedule_id = 301;
            booking.tickets_booked = 2;
            booking.ticket_price = 400;
            booking.created_at = DateTime.UtcNow;
            booking.updated_at = DateTime.UtcNow;
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            //return CreatedAtAction("Get", new { id = booking.booking_id }, booking);
            return Ok();
        }
    }
}

