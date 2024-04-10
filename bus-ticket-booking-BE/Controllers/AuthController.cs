using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using bus_ticket_booking_BE.Data;
using bus_ticket_booking_BE.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bus_ticket_booking_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private ApplicationDbContext _context;
        private IConfiguration _configuration;

        public AuthController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        public ActionResult Login([FromBody] JsonElement body)
        {
            var email = body.GetProperty("email").ToString();
            var password = body.GetProperty("password").ToString();
            var user = _context.Users.ToList().Find(p =>
                p.email == email && p.password == password);
            if (user == null)
            {
                return NotFound(email);
            }
            var claims = new[]
            {
                new Claim("email", user.email),
                new Claim("type", user.user_type),
                new Claim("first_name", user.first_name),
                new Claim("last_name", user.last_name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signin);

            return Ok((string)new JwtSecurityTokenHandler().WriteToken(token));
        }
      
    }
}

