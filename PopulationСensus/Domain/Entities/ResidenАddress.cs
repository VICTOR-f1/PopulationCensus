namespace PopulationСensus.Domain.Entities
{
    public class ResidenАddress : Entity
    {
        public int АddressId { get; set; }
        public Аddress Аddress { get; set; } = null!;

        // списк жителей, проживающих по данному адресу.
        public List<Resident> Resident { get; set; }

    }
}
