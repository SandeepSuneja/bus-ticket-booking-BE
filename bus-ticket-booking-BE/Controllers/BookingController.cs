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
        public async Task<ActionResult> AddBooking([FromBody] Booking booking)
        {
            booking.created_at = DateTime.UtcNow;
            booking.updated_at = DateTime.UtcNow;
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return Ok(booking.booking_id);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBooking(string id)
        {
            var booking = _context.Bookings.ToList().Find(p => p.booking_id == id);
            if (booking == null)
            {
                return NotFound();
            }
            _context.Bookings.ToList().Remove(booking);
            _context.SaveChanges();
            return Ok();
        }
    }
}

