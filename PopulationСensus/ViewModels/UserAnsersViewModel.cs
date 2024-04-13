using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PopulationСensus.ViewModels
{
    public class UserAnswerViewModel
    {



        [Required(ErrorMessage = "Не указан пол")]
        [Display(Name = "Пол")]
        public bool Gender { get; set; }

        [Required(ErrorMessage = "Не указано количество рожденных детей")]
        [Range(0, 30,ErrorMessage = "Не корректный ввод")]
        [Display(Name = "Количество рожденных вами детей")]
        public byte? NumberChildrenBorn { get; set; }

        [Required(ErrorMessage = "Не указан год рождения первого ребёнка")]
        [Range(1950, 2024, ErrorMessage = "Не корректный ввод")]
        [Display(Name = "Год рождения первого ребёнка")]
        public short? YearBirthFirstChild { get; set; }

        [Required(ErrorMessage = "Не указано место рождения")]
        [Display(Name = "Место рождения")]
        public string PlaceBirth { get; set; } = null!;

        //[Required(ErrorMessage = "Вы не указали жили ли вы в других странах")]
        //[Display(Name = "Жили ли вы в других странах")]
        //public bool LivedOtherCountries { get; set; }

        //[Required(ErrorMessage = "Вы не указали где вы жили до прибытия(возвращение) в РФ")]
        //[Display(Name = "Где вы жили до прибытия(возвращение) в РФ")]
        //public string WhereLiveBeforeArriving { get; set; } = null!;

        //[Required(ErrorMessage = "Вы не указали год прибытия(возвращение) в РФ")]
        //[Display(Name = "Год прибытия(возвращение) в РФ")]
        //public short YearArrival { get; set; }

        //[Required(ErrorMessage = "Не указано говорите ли вы русски?")]
        //[Display(Name = "Говорите ли вы русски")]
        //public bool SpeakRussian { get; set; }

        //[Required(ErrorMessage = "Не указано говорите ли вы русски?")]
        //[Display(Name = "Используете русский язык в повсденевной жизни")]
        //public bool UseRussianInConversation { get; set; }

        //[Required(ErrorMessage = "Вы не указали ваше гражданство")]
        //[Display(Name = "Ваше гражданство")]
        //public string NativeLanguage { get; set; } = null!;

        //[Required(ErrorMessage = "Вы не указали вашу нациальность")]
        //[Display(Name = "Ваша нациальность")]
        //public string Citizenship { get; set; } = null!;

        //[Required(ErrorMessage = "Вы не указали ваше образование")]
        //[Display(Name = "Ваше образование")]
        //public string Education { get; set; } = null!;

        //[Required(ErrorMessage = "Не указано  есть ли у вас учённая степень")]
        //[Display(Name = "Учённая степень")]
        //public bool HaveDegree { get; set; }

        //[Required(ErrorMessage = "Не указано  умеете ли вы писать и читать ")]
        //[Display(Name = "Умеете писать и читать ")]
        //public bool CanReadAndWrite { get; set; }
    }
}
