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

        [HttpGet("{origin}/{destination}")]
        public ActionResult<IEnumerable<Bus>> GetBusesByEnds(string origin, string destination)
        {
            List<Bus> buses = new List<Bus>();
            foreach(Bus bus in _context.Buses.ToList())
            {
                var route = _context.Routes.ToList().Find(p =>
                    p.route_id == bus.route_id && p.origin == origin && p.destination == destination);
                if (route != null)
                {
                    buses.Add(bus);
                }

            }
            if (buses == null)
            {
                return NotFound();
            }
            return Ok(buses);
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

