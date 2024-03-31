using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bus_ticket_booking_BE.Entities;

public enum BusStatus
{
    Arrived,
    Delayed,
    Departed
};

[Table("Bus")]
 public class Bus {

    [Key]
    public Guid bus_id { get; set; }

    [ForeignKey("route_id")]
    public Guid route_id { get; set; }

    [Required]
    public string bus_Number { get; set; }

    [Required]
    public int seat_capacity { get; set; }

    [Required]
    public BusStatus status { get; set; }

    [Required]
    public DateTime created_at { get; set; } = DateTime.UtcNow;

    public DateTime updated_at { get; set; } = DateTime.UtcNow;
 }