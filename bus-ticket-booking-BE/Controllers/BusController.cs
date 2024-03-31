using System;
using bus_ticket_booking_BE.Entities;
using bus_ticket_booking_BE.Data;
using Microsoft.AspNetCore.Mvc;

namespace bus_ticket_booking_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusController : ControllerBase
	{
        private ApplicationDbContext _context;
        public BusController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Bus>> GetBuses()
        {
            return _context.Buses.ToList();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStatus(int id, [FromQuery] string status)
        {
            var bus = _context.Buses.ToList().Find(p => p.bus_id == id);
            if (bus == null)
            {
                return NotFound();
            }
            
            bus.status = status;
            bus.updated_at = DateTime.UtcNow;
            _context.SaveChanges();
            return Ok();
        }
    }
}

