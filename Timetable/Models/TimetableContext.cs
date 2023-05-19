using Microsoft.EntityFrameworkCore;

namespace Timetable.Models;

public class TimetableContext : DbContext
{
    public TimetableContext(DbContextOptions<TimetableContext> options)
        : base(options)
    {
    }

    public DbSet<Trip> Trips { get; set; } = null!;
    public DbSet<Way> Ways { get; set; } = null!;
    public DbSet<Station> Stations { get; set; } = null!;
    public DbSet<StationAndWay> StationsAndWays { get; set; } = null!;
}
