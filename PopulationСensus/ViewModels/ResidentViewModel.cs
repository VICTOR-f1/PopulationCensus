using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PopulationСensus.ViewModels
{
    public class ResidentViewModel
    {
        [Required]
        [Display(Name = "Адресс")]
        public int AddressId { get; set; }
        public List<SelectListItem> Address { get; set; } = new();
            
        [Display(Name = "Полное имя")]
        public string FullName { get; set; } = null!;

        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        




    }
}
