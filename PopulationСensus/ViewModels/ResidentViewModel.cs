using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PopulationСensus.ViewModels
{
    public class ResidentViewModel
    {
      
        [Required(ErrorMessage = "Не указано имя")]
        [Display(Name = "Полное имя")]
        public string FullName { get; set; } = null!;
        [Required (ErrorMessage = "Не указана дата рождения")]
        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Не указана улица")]
        [Display(Name = "Улица")]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "Не указан город")]
        [Display(Name = "Город")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Не указана область")]
        [Display(Name = "Область")]
        public string State { get; set; } = null!;

        [Required(ErrorMessage = "Не указан номер улицы")]
        [Display(Name = "Номер улицы")]
        public short ApartmentNumber { get; set; }

        [Required(ErrorMessage = "Не указан индекс")]
        [Display(Name = "Индекс")]
        public int ZipCode { get; set; }


    }
}
