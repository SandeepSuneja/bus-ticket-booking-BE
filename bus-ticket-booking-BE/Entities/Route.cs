using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bus_ticket_booking_BE.Entities;

[Table("Route")]
public class Route {

    [Key]
    public int route_id { get; set; }

    [Required]
    public string origin { get; set; }

    [Required]
    public string destination { get; set; }

    [Required]
    public float duration { get; set; }

    [Required]
    public string status { get; set; }

    [Required]
    public DateTime created_at { get; set; } = DateTime.UtcNow;

    [Required]
    public DateTime updated_at { get; set; } = DateTime.UtcNow;
}