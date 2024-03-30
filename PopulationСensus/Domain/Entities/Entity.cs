using System.ComponentModel.DataAnnotations;

namespace PopulationСensus.Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
