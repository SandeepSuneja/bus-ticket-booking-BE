using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bus_ticket_booking_BE.Entities
{
	[Table("User")]
	public class User
	{
		[Required]
		[MaxLength(20)]
		public string first_name { get; set; }

		[Required]
		[MaxLength(20)]
		public string last_name { get; set; }

		[Key]
		[MaxLength(50)]
		public string email { get; set; }

		[Required]
		[MaxLength(20)]
		public string password { get; set; }

		[Required]
		[MaxLength(10)]
		public string phone_number { get; set; }

		[Required]
		[MaxLength(200)]
		public string address { get; set; }

		[Required]
		public string user_type { get; set; }

		[Required]
		public DateTime created_at { get; set; } = DateTime.UtcNow;

		public DateTime updated_at { get; set; } = DateTime.UtcNow;
	}
}

