using System.ComponentModel.DataAnnotations;

namespace ArbetsUppdrag.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [MaxLength(50), Required(ErrorMessage = "You should provide a name value with less than 50 characters")]
        public string LocationName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        [MaxLength(50)]
        public string LocationCountry { get; set; }
    }
}
