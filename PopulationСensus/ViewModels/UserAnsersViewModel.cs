using System.ComponentModel.DataAnnotations;

namespace PopulationСensus.ViewModels
{
    public class UserAnswerViewModel
    {
        [Required(ErrorMessage = "Не указан пол")]
        [Display(Name = "Пол")]
        public bool Gender { get; set; }

        [Range(0, 30, ErrorMessage = "Не корректный ввод")]
        [Required(ErrorMessage = "Не указано количество детей ")]
        [Display(Name = "Сколько детей у вас")]
        public byte? NumberChildrenBorn { get; set; }

        [Range(0, 20, ErrorMessage = "Не корректный ввод")]
        [Required(ErrorMessage = "Не указано число людей проживающих в вашем домохозайстве ")]
        [Display(Name = "Число людей проживающих в вашем домохозайстве")]
        public short? CountPeopleLivingHousehold { get; set; }

        [MinLength(3, ErrorMessage = "Место рождения не может быть короче трёх букв")]
        [MaxLength(70, ErrorMessage = "Место рождения не может быть длинее тридцати букв")]
        [Required(ErrorMessage = "Не указано место рождения")]
        [Display(Name = "Место рождения")]
        public string PlaceBirth { get; set; } = null!;
        
        [MinLength(3, ErrorMessage = "Язык не может быть короче четерёх букв")]
        [MaxLength(70, ErrorMessage = "Язык не может быть длинее тридцати букв")]
        [Required(ErrorMessage = "Вы не указали ваш родной язык")]
        [Display(Name = "Ваш родной язык")]
        public string NativeLanguage { get; set; } = null!;

        [MinLength(4, ErrorMessage = "Нациальность не может быть короче четерёх букв")]
        [MaxLength(30, ErrorMessage = "Нациальность не может быть длинее тридцати букв")]
        [Required(ErrorMessage = "Вы не указали вашу нациальность")]
        [Display(Name = "Ваша нациальность")]
        public string Nationality { get; set; } = null!;

        [MinLength(3, ErrorMessage = "Гражданство не может быть короче четерёх букв")]
        [MaxLength(70, ErrorMessage = "Гражданство не может быть длинее тридцати букв")]
        [Required(ErrorMessage = "Вы не указали ваше гражданство")]
        [Display(Name = "Ваше гражданство")]
        public string Citizenship { get; set; } = null!;

        [Required(ErrorMessage = "Вы не указали ваше образование")]
        [Display(Name = "Ваше образование")]
        public string Education { get; set; } = null!;
        
        [Required(ErrorMessage = "Не указано ваше состяние в браке")]
        [Display(Name = "Ваше состяние в браке")]
        public string MaritalStatus { get; set; } = null!;

        [Display(Name = "Тип жилища")]
        public string TypeOfDwelling { get; set; } = null!;

        [Display(Name = "Получаете ли вы образование в настоящее время")]
        public string GettingEducation { get; set; } = null!;

        [Display(Name = "Основной источник средств к существованию")]
        public string SourcesOfLiveliHood { get; set; } = null!;

        [Display(Name = "Имели ли Вы какую-либо оплачиваемую работу или доходное занятие с 24 по 30 сентября 2020 года")]
        public bool HaveWorkedRecently { get; set; }

        [Display(Name = "Кем вы являлись на основной работе")]
        public string WhoWereMainJob { get; set; } = null!;

        [Display(Name = "Отопление")]
        public string Heating { get; set; } = null!;

        [Display(Name = "Водоснабжение")]
        public string WaterSupply { get; set; } = null!;

        [Display(Name = "Горячее водоснабжение")]
        public string HotWaterSupply { get; set; } = null!;

        [Display(Name = "Водоотведение(канализация)")]
        public string WaterDisposalSewerage { get; set; } = null!;

        [Display(Name = "Удаление бытовых отходов")]
        public string DisposalOfHouseholdWaste { get; set; } = null!;
    }
}
