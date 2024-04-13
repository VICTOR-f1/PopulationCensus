using System.ComponentModel.DataAnnotations;

namespace PopulationСensus.ViewModels
{
    public class RegistrationViewModel
    {
        [MinLength(5, ErrorMessage = "ФИО не может быть короче двух символов")]
        [MaxLength(250, ErrorMessage = "Максимальная длина ФИО составляет 100 символов")]
        [Required(ErrorMessage = "Не указано ФИО")]
        [Display(Name = "ФИО")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Не указана дата рождения")]
        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        [MinLength(3, ErrorMessage = "Длинна почты не должна быть меньше трёх символов")]
        [MaxLength(150, ErrorMessage = "Длина почты не должна превышать сто пятьдесят символов")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Некоректная почта")]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "Пароль должен быть длиной 8 или более символов")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Не указан пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Не указан пароль")]
        [Display(Name = "Подтвердите пароль")]
        public string RepeatPassword { get; set; }

        [Required(ErrorMessage = "Не указана улица")]
        [Display(Name = "Улица")]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "Не указан город")]
        [Display(Name = "Город")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Не указана область")]
        [Display(Name = "Область")]
        public string State { get; set; } = null!;

        [Required(ErrorMessage = "Не указан номер дома")]
        [Display(Name = "Номер дома")]
        public short? ApartmentNumber { get; set; }

        [Required(ErrorMessage = "Не указан индекс")]
        [Display(Name = "Индекс")]
        public int? ZipCode { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона")]
        [Display(Name = "Номер телефона")]
        [MinLength(10, ErrorMessage = "Номер телефона не может быть короче десяти цифр")]
        [MaxLength(11, ErrorMessage = "Максимальная длина номера составляет одинадцать цифр")]
        public string PhoneNumber { get; set; }
    }
}
