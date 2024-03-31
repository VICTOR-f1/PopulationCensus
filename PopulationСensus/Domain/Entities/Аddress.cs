using System.ComponentModel.DataAnnotations;

namespace PopulationСensus.Domain.Entities
{
    public class Аddress:Entity
    {
        public short ZipCode { get; set; }
        public  short ApartmentNumber { get; set; }

        [StringLength(150)]
        public string Street { get; set; } = null!;

        [StringLength(30)]
        public string City { get; set; } = null!;

        [StringLength(30)]
        public string State { get; set; } = null!;
        public List<ResidenАddress> ResidenАddress { get; set; }

    }
}
