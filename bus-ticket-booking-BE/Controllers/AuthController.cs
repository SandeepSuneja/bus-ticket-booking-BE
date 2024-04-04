using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bus_ticket_booking_BE.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bus_ticket_booking_BE.Controllers
{
    public class AuthController : Controller
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] Credentials credentials)
        {
            var token = _jwtService.GenerateToken(credentials.email);
            return Ok(new { Token = token });
        }
      
    }
}

