using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KBS_FunEvents_Web_2025.Models.ViewModels
{
    public class AktiveBuchungenViewModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Bezeichnung*")]
        [Display(Name = "Name des Events")]
        [DataType(DataType.Text)]
        public string EtBezeichnung { get; set; }

        [Required(ErrorMessage = "Beginn*")]
        [Display(Name = "Start des Events")]
        [DataType(DataType.DateTime)]
        public DateTime EdBeginn { get; set; }

        [Required(ErrorMessage = "Startort*")]
        [Display(Name = "Startort")]
        [DataType(DataType.Text)]
        public string EdStartOrt { get; set; }

        
        [Required(ErrorMessage = "Gebuchte Plätze*")]
        [Display(Name = "Gebuchte Plätze")]
        [DataType(DataType.Text)]
        public int gebuchtePlaetze {  get; set; }

        [Required(ErrorMessage = "Teilnehmer*")]
        [Display(Name = "Gebuchte Plätze")]
        [DataType(DataType.Text)]
        public int EdAktTeilnehmer { get; set; }
    }
}
