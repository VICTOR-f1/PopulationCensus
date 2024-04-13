using System.ComponentModel.DataAnnotations;

namespace PopulationСensus.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Укажите почту")]
        [MinLength(3, ErrorMessage = "Длинна почты не должна быть меньше трёх символов")]
        [MaxLength(150, ErrorMessage = "Длина почты не должна превышать сто пятьдесят символов")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Некоректная почта")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
