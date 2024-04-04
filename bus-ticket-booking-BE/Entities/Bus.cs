using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bus_ticket_booking_BE.Entities;

[Table("Bus")]
 public class Bus {

    [Key]
    public int bus_id { get; set; }

    [ForeignKey("route_id")]
    public int route_id { get; set; }

    [Required]
    public string bus_number { get; set; }

    [Required]
    public int seat_capacity { get; set; }

    [Required]
    public string status { get; set; }

    [Required]
    public DateTime created_at { get; set; } = DateTime.UtcNow;

    public DateTime updated_at { get; set; } = DateTime.UtcNow;

    [ForeignKey("schedule_id")]
    public int schedule_id { get; set; }

    [Required]
    public int ticket_price { get; set; }

    [Required]
    public int seat_occupied { get; set; }
}