using System.ComponentModel.DataAnnotations;

namespace PopulationСensus.Domain.Entities
{
    public class Resident : Entity
    {
        [StringLength(250)]
        public string FullName { get; set; } = null!;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;
    }
}
