using System.ComponentModel.DataAnnotations;

namespace PopulationСensus.ViewModels
{
    public class RegistrationViewModel
    {
        [MinLength(2, ErrorMessage = "Имя не может быть короче двух символов")]
        [MaxLength(50, ErrorMessage = "Максимальная длина имени составляет 50 знаков")]
        public string Fullname { get; set; }

        [MinLength(3, ErrorMessage = "Имя пользователя должно быть 3 или более символов")]
        [MaxLength(50, ErrorMessage = "Имя пользователя не должно превышать 50 символов")]
        [RegularExpression(@"[A-Za-z0-9_]*",
            ErrorMessage = "Имя пользователя должно содержать только латинские символы, цифры и символ подчеркивания")]
        public string Username { get; set; }

        [MinLength(8, ErrorMessage = "Пароль должен быть длиной 8 или более символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
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
        public short ApartmentNumber { get; set; }

        [Required(ErrorMessage = "Не указан индекс")]
        [Display(Name = "Индекс")]
        public int ZipCode { get; set; }
    }
}
