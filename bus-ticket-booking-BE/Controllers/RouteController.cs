using bus_ticket_booking_BE.Data;
using bus_ticket_booking_BE.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bus_ticket_booking_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouteController : Controller
    {
        private ApplicationDbContext _context;
        public RouteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Entities.Route>> GetRoutes()
        {
            return _context.Routes.ToList();
        }

        [HttpPut("{id}")]
        public ActionResult ToggleStatus(int id)
        {
            var route = _context.Routes.ToList().Find(route => route.route_id == id);
        
            if(route == null)
            {
                return NotFound();
            }

            if(route.status == "Enabled")
            {
                route.status = "Disabled";
            }
            else if (route.status == "Disabled")
            {
                route.status = "Enabled";
            }
            route.updated_at = DateTime.UtcNow;
            _context.SaveChanges();
            return Ok();
        }
    }
}

