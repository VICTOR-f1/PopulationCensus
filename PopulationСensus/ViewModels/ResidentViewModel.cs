using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PopulationСensus.ViewModels
{
    public class ResidentViewModel
    {
        [Required(ErrorMessage = "Не указан адресс")]
        [Display(Name = "Адресс")]
        public int AddressId { get; set; }
        public List<SelectListItem> Address { get; set; } = new();
        [Required(ErrorMessage = "Не указано имя")]
        [Display(Name = "Полное имя")]
        public string FullName { get; set; } = null!;
        [Required (ErrorMessage = "Не указана дата рождения")]
        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Не указана улица")]
        [Display(Name = "Улица")]
        public string Street { get; set; }



    }
}
