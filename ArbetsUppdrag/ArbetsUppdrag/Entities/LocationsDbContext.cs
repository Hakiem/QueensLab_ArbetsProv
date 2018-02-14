using Microsoft.EntityFrameworkCore;
using ArbetsUppdrag.Models;

namespace ArbetsUppdrag.Entities
{
    public class LocationsDbContext : DbContext
    {
        public LocationsDbContext(DbContextOptions options) : base(options) => Database.EnsureCreated();

        public DbSet<Location> Locations { get; set; }
    }
}
