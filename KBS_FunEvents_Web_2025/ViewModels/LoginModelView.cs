using System.ComponentModel.DataAnnotations;

namespace KBS_FunEvents_Web_2025.ViewModels
{
    public class LoginModelView
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Email*")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string kdEmail { get; set; }

        [Required(ErrorMessage = "Passwort*")]
        [Display(Name = "Passwort")]
        [DataType(DataType.Password)]
        public string kdPwHash { get; set; }

    }
}
