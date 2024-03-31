using System.ComponentModel.DataAnnotations;

namespace PopulationСensus.Domain.Entities
{
    public class Resident : Entity
    {
        [StringLength(150)]
        public string FullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public int ResidenАddressId { get; set; }
        public ResidenАddress ResidenАddress { get; set; } = null!;
    }
}
