using Microsoft.AspNetCore.Mvc.Rendering;
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
        public List<SelectListItem> NumberChildrenBornSelectList { get; set; } = new();
        public List<SelectListItem> WhereLiveBeforeArrivingSelectList { get; set; } = new();
        public List<SelectListItem> NativeLanguageSelectList { get; set; } = new();
        public List<SelectListItem> StateSelectList { get; set; } = new();
        public List<SelectListItem> CitizenshipSelectList { get; set; } = new();
        public List<SelectListItem> NationalitySelectList { get; set; } = new();
        public List<SelectListItem> AgeStartSelectList { get; set; } = new();
        public List<SelectListItem> AgeEndSelectList { get; set; } = new();
        public List<User> User { get; set; }
        public List<Address> Address { get; set; }
        public List<UserAnswer> UserAnswers { get; set; }

        [Display(Name = "Пол")]
        public string Gender { get; set; }

        [Display(Name = "Сколько детей у вас")]
        public byte? NumberChildrenBorn { get; set; }
        public  int AgeStartId { get; set; }
        public int AgeEndId { get; set; }

        [Display(Name = "Число людей проживающих в вашем домохозайстве")]
        public short? CountPeopleLivingHousehold { get; set; }

        [Display(Name = "Место рождения")]
        public string PlaceBirth { get; set; } = null!;
        
        [Display(Name = "Ваш родной язык")]
        public string NativeLanguage { get; set; } = null!;

        [Display(Name = "Ваша нациальность")]
        public string Nationality { get; set; } = null!;

        [Display(Name = "Ваше гражданство")]
        public string Citizenship { get; set; } = null!;

        [Display(Name = "Ваше образование")]
        public string Education { get; set; } = null!;
        
        [Display(Name = "Ваше состяние в браке")]
        public string MaritalStatus { get; set; } = null!;

        [Display(Name = "Тип жилища")]
        public string TypeOfDwelling { get; set; } = null!;

        [Display(Name = "Получаете ли вы образование в настоящее время")]
        public string GettingEducation { get; set; } = null!;

        [Display(Name = "Основной источник средств к существованию")]
        public string SourcesOfLiveliHood { get; set; } = null!;

        [Display(Name = "Имели ли Вы какую-либо оплачиваемую работу или доходное занятие с 24 по 30 сентября 2020 года")]
        public string HaveWorkedRecently { get; set; }

        [Display(Name = "Кем вы являлись на основной работе")]
        public string WhoWereMainJob { get; set; } = null!;

        [Display(Name = "Отопление")]
        public string Heating { get; set; } = null!;

        [Display(Name = "Водоснабжение")]
        public string WaterSupply { get; set; } = null!;

        [Display(Name = "Район")]
        public string State { get; set; } = null!;

        [Display(Name = "Горячее водоснабжение")]
        public string HotWaterSupply { get; set; } = null!;

        [Display(Name = "Водоотведение(канализация)")]
        public string WaterDisposalSewerage { get; set; } = null!;

        [Display(Name = "Удаление бытовых отходов")]
        public string DisposalOfHouseholdWaste { get; set; } = null!;

    }
}
