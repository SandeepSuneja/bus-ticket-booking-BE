using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace bus_ticket_booking_BE.Entities
{
	public class JwtService
	{
		private readonly string _secretKey;
		private readonly int _expiryInMinutes;

		public JwtService(string secretKey, int expiryInMinues)
		{
			_secretKey = secretKey;
			_expiryInMinutes = expiryInMinues;
		}

		public string GenerateToken(User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_secretKey);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
                Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.email)
				}),
                Expires = DateTime.UtcNow.AddMinutes(_expiryInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
	}
}

