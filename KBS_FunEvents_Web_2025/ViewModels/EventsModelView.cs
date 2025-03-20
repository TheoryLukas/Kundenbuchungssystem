using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KBS_Web.Models;

namespace KBS_FunEvents_Web_2025.ViewModels;

public partial class TblEvent
{
    [Column("ev_EvVeranstalterID")]
    public int EvEvVeranstalterId { get; set; }

    [Column("ek_EvKategorieID")]
    public int EkEvKategorieId { get; set; }

    [Required]
    [Column("et_Bezeichnung")]
    [StringLength(50)]
    public string EtBezeichnung { get; set; }

    [Column("et_Beschreibung", TypeName = "text")]
    public string EtBeschreibung { get; set; }

    [ForeignKey("EkEvKategorieId")]
    [InverseProperty("TblEvents")]
    public virtual TblEvKategorie EkEvKategorie { get; set; }

    [ForeignKey("EvEvVeranstalterId")]
    [InverseProperty("TblEvents")]
    public virtual TblEvVeranstalter EvEvVeranstalter { get; set; }

    [InverseProperty("EtEvent")]
    public virtual ICollection<TblEventDaten> TblEventDatens { get; set; } = new List<TblEventDaten>();
}