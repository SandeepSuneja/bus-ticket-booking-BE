using bus_ticket_booking_BE.Entities;
using Microsoft.EntityFrameworkCore;

namespace bus_ticket_booking_BE.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Bus> Buses { get; set; }
    public DbSet<bus_ticket_booking_BE.Entities.Route> Routes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Booking> Bookings { get; set; }
 }