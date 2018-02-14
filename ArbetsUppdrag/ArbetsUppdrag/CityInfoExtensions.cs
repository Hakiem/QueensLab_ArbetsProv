using ArbetsUppdrag.Entities;
using ArbetsUppdrag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbetsUppdrag
{
    public static class CityInfoExtensions
    {
        public static void EnsureSeedDataForContext(this LocationsDbContext context)
        {
            if (context.Locations.Any())
            {
                return;
            }
            var Locs = new List<Location>()
            {
                 new Location { LocationName = "Gothenburg", Latitude = 57.708870, Longitude = 11.974560, LocationCountry = "Sweden"},
                 new Location { LocationName = "Stockholm", Latitude = 59.329323, Longitude = 18.068571 , LocationCountry = "Sweden" },
                 new Location { LocationName = "Malmo", Latitude = 55.610, Longitude = 13.020 , LocationCountry = "Sweden" },
                 new Location { LocationName = "Oslo", Latitude = 59.911491, Longitude = 10.75793 , LocationCountry = "Norway" },
                 new Location { LocationName = "Umea", Latitude = 63.825848, Longitude = 20.263035 , LocationCountry = "Sweden" },
                 new Location { LocationName = "Västerås", Latitude = 59.611366, Longitude = 16.545025 , LocationCountry = "Sweden" },
                 new Location { LocationName = "Uddevalla", Latitude = 58.351307, Longitude = 11.885834 , LocationCountry = "Sweden" },
                 new Location { LocationName = "Visby", Latitude = 57.634800, Longitude = 18.294840 , LocationCountry = "Sweden" },
                 new Location { LocationName = "Madrid", Latitude = 40.416775, Longitude = -3.703790 , LocationCountry = "Spain" },
                 new Location { LocationName = "Barcelona", Latitude = 41.390205, Longitude = 2.154007 , LocationCountry = "Spain" },
                 new Location { LocationName = "Copenhagen", Latitude = 55.676098, Longitude = 12.568337 , LocationCountry = "Denmark" },
                 new Location { LocationName = "Alborg", Latitude = 57.046707, Longitude = 9.935932 , LocationCountry = "Denmark" },
                 new Location { LocationName = "Cologne", Latitude = 50.933594, Longitude = 6.961899 , LocationCountry = "Germany" },
                 new Location { LocationName = "Berlin", Latitude = 52.520008, Longitude = 52.520008 , LocationCountry = "Germany" },
                 new Location { LocationName = "Helsinki", Latitude = 60.192059   , Longitude = 24.945831 , LocationCountry = "Finland" },
                 new Location { LocationName = "Hanko", Latitude = 59.832394, Longitude = 22.970695 , LocationCountry = "Finland" },
                 new Location { LocationName = "Stavangar", Latitude = 58.969975, Longitude = 5.733107 , LocationCountry = "Norway" }
            };
            
            context.Locations.AddRange(Locs);
            context.SaveChanges();
        }
    }
}
