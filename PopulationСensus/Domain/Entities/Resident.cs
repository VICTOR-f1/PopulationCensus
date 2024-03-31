using System.ComponentModel.DataAnnotations;

namespace PopulationСensus.Domain.Entities
{
    public class Resident : Entity
    {
        [StringLength(150)]
        public string FullName { get; set; } = null!;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public int АddressId { get; set; }
        public Address Аddress { get; set; } = null!;
    }
}
