using System.ComponentModel.DataAnnotations;

namespace PopulationСensus.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Укажите почту")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
