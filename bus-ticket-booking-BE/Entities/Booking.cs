﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bus_ticket_booking_BE.Entities
{
	[Table("Booking")]
	public class Booking
	{
		[Key]
		public string booking_id { get; set; }

		[Required]
		[ForeignKey("bus_id")]
		public int bus_id { get; set; }

		[Required]
		[ForeignKey("route_id")]
		public int route_id { get; set; }

		[Required]
		[ForeignKey("schedule_id")]
		public int schedule_id { get; set; }

		[Required]
		public int tickets_booked { get; set; }

		[Required]
		public float ticket_price { get; set; }

		[Required]
		public DateTime created_at { get; set; }

		public DateTime updated_at { get; set; }
	}
}

