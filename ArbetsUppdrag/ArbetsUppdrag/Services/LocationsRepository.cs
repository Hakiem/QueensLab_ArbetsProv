using System.Collections.Generic;
using System.Linq;
using ArbetsUppdrag.Entities;
using ArbetsUppdrag.Models;

namespace ArbetsUppdrag.Services
{
    public class LocationsRepository : ILocationsRepository<Location>
    {
        LocationsDbContext _context;
        public LocationsRepository(LocationsDbContext context) => _context = context;

        public bool EntityExists(int id) => _context.Locations.Any(x => x.LocationId == id);

        IEnumerable<Location> ILocationsRepository<Location>.GetAll() => _context.Locations.OrderBy(k => k.LocationName).ToList();

        Location ILocationsRepository<Location>.GetById(int id) => _context.Locations.Where(i => i.LocationId == id).FirstOrDefault();
    }
}
