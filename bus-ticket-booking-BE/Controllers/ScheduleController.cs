﻿using bus_ticket_booking_BE.Data;
using bus_ticket_booking_BE.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bus_ticket_booking_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : Controller
    {
        private ApplicationDbContext _context;

        public ScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Schedule>> GetSchedules() 
        {
            return _context.Schedules.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Schedule>> GetScheduleById(int id)
        {
            var schedule = _context.Schedules.ToList().Find(x => x.schedule_id == id);
            if (schedule == null)
            {
                return NotFound();
            }
            return Ok(schedule);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSchedule(int id)
        {
            var schedule = _context.Schedules.ToList().Find(p => p.schedule_id == id);
            if (schedule == null)
            {
                return NotFound();
            }
            _context.Schedules.ToList().Remove(schedule);
            _context.SaveChanges();
            return Ok();
        }
    }
}

