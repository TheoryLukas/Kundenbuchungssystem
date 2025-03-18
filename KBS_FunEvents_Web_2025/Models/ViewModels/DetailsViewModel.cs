using System.ComponentModel.DataAnnotations;

namespace KBS_FunEvents_Web_2025.Models.ViewModels
{
    public class DetailsViewModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Bezeichnung*")]
        [Display(Name = "Name des Events")]
        [DataType(DataType.Text)]
        public string EtBezeichnung { get; set; }

        [Required(ErrorMessage = "Beschreibung*")]
        [Display(Name = "Beschreibung des Events")]
        [DataType(DataType.Text)]
        public string EtBeschreibung { get; set; }

        [Required(ErrorMessage = "Veranstalter*")]
        [Display(Name = "Veranstalter")]
        [DataType(DataType.Text)]
        public string EvFirma { get; set; }

        [Required(ErrorMessage = "Kategorie*")]
        [Display(Name = "Kategorie")]
        [DataType(DataType.Text)]
        public string EkKatBezeichnung { get; set; }

        [Required(ErrorMessage = "Beginn*")]
        [Display(Name = "Start des Events")]
        [DataType(DataType.DateTime)]
        public DateTime EdBeginn { get; set; }

        [Required(ErrorMessage = "Ende*")]
        [Display(Name = "Ende des Events")]
        [DataType(DataType.DateTime)]
        public DateTime EdEnde { get; set; }

        [Required(ErrorMessage = "Startort*")]
        [Display(Name = "Startort")]
        [DataType(DataType.Text)]
        public string EdStartOrt { get; set; }

        [Required(ErrorMessage = "Zielort*")]
        [Display(Name = "Zielort")]
        [DataType(DataType.Text)]
        public string EdZielort { get; set; }

        [Required(ErrorMessage = "Teilnehmer*")]
        [Display(Name = "Gebuchte Plätze")]
        [DataType(DataType.Text)]
        public int EdAktTeilnehmer { get; set; }

        [Required(ErrorMessage = "Preis*")]
        [Display(Name = "Preis pro Teilnehmer")]
        [DataType(DataType.Text)]
        public decimal EdPreis { get; set; }

        /*[Required(ErrorMessage = "Stornieren*")]
        [Display(Name = "Buchung stornieren")]
        [DataType(DataType.Text)]
        public bool BuStorniert { get; set; }

        [Required(ErrorMessage = "KundenID*")]
        [Display(Name = "KundenID")]
        [DataType(DataType.Text)]
        public int KdKundenId { get; set; }*/
    }
}
