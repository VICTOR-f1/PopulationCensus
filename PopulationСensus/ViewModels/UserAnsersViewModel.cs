using System.ComponentModel.DataAnnotations;

namespace PopulationСensus.ViewModels
{
    public class UserAnswerViewModel
    {
        [Required(ErrorMessage = "Не указан пол")]
        [Display(Name = "Пол")]
        public bool Gender { get; set; }

        [Range(0, 30,ErrorMessage = "Не корректный ввод")]
        [Display(Name = "Количество рожденных вами детей")]
        public byte? NumberChildrenBorn { get; set; }

        [Range(1950, 2024, ErrorMessage = "Не корректный ввод")]
        [Display(Name = "Год рождения первого ребёнка")]
        public short? YearBirthFirstChild { get; set; }

        [MinLength(3, ErrorMessage = "Место рождения не может быть короче трёх букв")]
        [MaxLength(70, ErrorMessage = "Место рождения не может быть длинее тридцати букв")]
        [Required(ErrorMessage = "Не указано место рождения")]
        [Display(Name = "Место рождения")]
        public string PlaceBirth { get; set; } = null!;

        [Required(ErrorMessage = "Вы не указали жили ли вы в других странах")]
        [Display(Name = "Жили ли вы в других странах более года")]
        public bool LivedOtherCountries { get; set; }

        [MinLength(3, ErrorMessage = "Странна не может быть короче трёх букв")]
        [MaxLength(70, ErrorMessage = "Странна не может быть длинее тридцати букв")]
        [Display(Name = "Где вы жили до прибытия (возвращение) в РФ")]
        public string WhereLiveBeforeArriving { get; set; } = null!;

        [Display(Name = "Год прибытия(возвращение) в РФ")]
        public short? YearArrival { get; set; }

        [Required(ErrorMessage = "Не указано говорите ли вы русски?")]
        [Display(Name = "Говорите ли вы русски?")]
        public bool SpeakRussian { get; set; }

        [Required(ErrorMessage = "Не указано говорите ли вы русски?")]
        [Display(Name = "Используйте русский в жизни?")]
        public bool UseRussianInConversation { get; set; }

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

        [Required(ErrorMessage = "Не указано есть ли у вас учённая степень")]
        [Display(Name = "Имете учённую степень?")]
        public bool HaveDegree { get; set; }

        [Required(ErrorMessage = "Не указано умеете ли вы писать и читать")]
        [Display(Name = "Умеете писать и читать?")]
        public bool CanReadAndWrite { get; set; }

        [Required(ErrorMessage = "Не указано ваше состяние в браке")]
        [Display(Name = "Ваше состяние в браке")]
        public string MaritalStatus { get; set; } = null!;
    }
}
