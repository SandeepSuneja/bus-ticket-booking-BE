using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bus_ticket_booking_BE.Entities
{
    [Table("Schedule")]
    public class Schedule
    {
        [Key]
        public int schedule_id { get; set; }

        [Required]
        [ForeignKey("bus_id")]
        public int bus_id { get; set; }

        [Required]
        public TimeOnly departure_time { get; set; }

        [Required]
        public TimeOnly arrival_time { get; set; }

        [Required]
        public DateTime created_at { get; set; } = DateTime.UtcNow;

        public DateTime updated_at { get; set; } = DateTime.UtcNow;
    }
}

