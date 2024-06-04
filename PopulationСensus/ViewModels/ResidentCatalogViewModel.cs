using PopulationСensus.Domain.Entities;

namespace PopulationСensus.ViewModels
{
    public class ResidentCatalogViewModel
    {
        public List<User> User { get; set; }
        public List<Address> Address { get; set; }
        public List<UserAnswer> UserAnswers { get; set; }

    }
}
