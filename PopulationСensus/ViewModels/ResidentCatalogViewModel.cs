﻿using Microsoft.AspNetCore.Mvc.Rendering;
using PopulationСensus.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PopulationСensus.ViewModels
{
    public class ResidentCatalogViewModel
    {
        public int? UserAnswerId { get; set; }

        [Display(Name = "Начальная дата")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "2024-03-22", "2025-01-01", ErrorMessage = "Самая первая билютень была заполненна в 2024-03-22")]
        public DateTime? DateFirst { get; set; }

        [Display(Name = "Конечная дата")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "2024-03-22", "2025-01-01", ErrorMessage = "Слишком большая или маленькая дата ввода")]
        public DateTime? DateSecond{ get; set; }
        public List<SelectListItem> UserAnswersSelectList { get; set; } = new();
        public List<SelectListItem> WhereLiveBeforeArrivingSelectList { get; set; } = new();
        public List<SelectListItem> NativeLanguage { get; set; } = new();
        public List<SelectListItem> State { get; set; } = new();
        public List<SelectListItem> Citizenship { get; set; } = new();
        public List<SelectListItem> Nationality { get; set; } = new();

        public List<User> User { get; set; }
        public List<Address> Address { get; set; }
        public List<UserAnswer> UserAnswers { get; set; }

    }
}
