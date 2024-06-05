using Microsoft.AspNetCore.Mvc.Rendering;
using PopulationСensus.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PopulationСensus.ViewModels
{
    public class ResidentCatalogViewModel
    {
        public int? UserAnswerId { get; set; }
        public List<SelectListItem> UserAnswersSelectList { get; set; } = new();
        public List<SelectListItem> WhereLiveBeforeArrivingSelectList { get; set; } = new();
        public List<User> User { get; set; }
        public List<Address> Address { get; set; }
        public List<UserAnswer> UserAnswers { get; set; }

    }
}
