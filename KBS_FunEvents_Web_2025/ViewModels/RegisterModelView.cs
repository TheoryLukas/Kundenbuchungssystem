using System.ComponentModel.DataAnnotations;

namespace KBS_FunEvents_Web_2025.ViewModels
{
    public class RegisterModelView
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Nachname*")]
        [Display(Name = "Nachname")]
        [DataType(DataType.Text)]
        public string kdNachname { get; set; }

        [Required(ErrorMessage = "Vorname*")]
        [Display(Name = "Vorname")]
        [DataType(DataType.Text)]
        public string kdVorname { get; set; }

        [Required(ErrorMessage = "Strasse*")]
        [Display(Name = "Strasse")]
        [DataType(DataType.Text)]
        public string kdStrasse { get; set; }

        [Required(ErrorMessage = "Hausnummer*")]
        [Display(Name = "Hausnummer")]
        [DataType(DataType.Text)]
        public string kdHNummer { get; set; }

        [Required(ErrorMessage = "Postleitzahl*")]
        [Display(Name = "Postleitzahl")]
        [DataType(DataType.Text)]
        public string kdPLZ { get; set; }

        [Required(ErrorMessage = "Ort*")]
        [Display(Name = "Ort")]
        [DataType(DataType.Text)]
        public string kdOrt { get; set; }

        [Required(ErrorMessage = "Telefon*")]
        [Display(Name = "Telefon")]
        [DataType(DataType.Text)]
        public string kdTelefon { get; set; }

        [Required(ErrorMessage = "Email*")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string kdEmail { get; set; }


        [Required(ErrorMessage = "Email stimmt nicht überein*")]
        [Display(Name = "Email wiederholen")]
        [DataType(DataType.EmailAddress)]
        [Compare("kdEmail", ErrorMessage = "Die E-Mail-Adressen stimmen nicht überein.")]
        public string kdEmailRepeat { get; set; }

        [Required(ErrorMessage = "Passwort*")]
        [Display(Name = "Passwort")]
        [DataType(DataType.Password)]
        public string kdPwHash { get; set; }

        [Required(ErrorMessage = "Passwörter stimmen nicht überein*")]
        [Display(Name = "Passwort wiederholen")]
        [DataType(DataType.Password)]
        [Compare("kdPwHash", ErrorMessage = "Die Passwörter stimmen nicht überein.")]
        public string kdPwHashRepeat { get; set; }

    }
}
