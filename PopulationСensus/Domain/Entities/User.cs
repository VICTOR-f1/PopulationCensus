using System.ComponentModel.DataAnnotations;

namespace PopulationСensus.Domain.Entities
{
    public class User : Entity
    {
         [StringLength(250)]
        public string FullName { get; set; } = null!;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(150)]
        public string Email { get; set; } = null!;

        [StringLength(256)]
        public string Password { get; set; } = null!;

        [StringLength(100)]
        public string Salt { get; set; } = null!;

        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;
    }
}
