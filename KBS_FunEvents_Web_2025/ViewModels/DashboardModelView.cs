using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KBS_FunEvents_Web_2025.ViewModels
{
    public class DashboardModelView
    {
        [Key]
        public int bu_BuchungsId { get; set; }

        public int ed_EventDatenId { get; set; }
        public int kd_KundenId { get; set; }

        [Display(Name = "Bezeichnung")]
        public string et_Bezeichnung { get; set; }

        [Display(Name = "Beschreibung")]
        public string et_Beschreibung { get; set; }

        [Display(Name = "Beginn")]
        public DateTime ed_Beginn { get; set; }
    }
}
