using System.ComponentModel.DataAnnotations;

namespace KBS_FunEvents_Web_2025.ViewModels;

public partial class EventModelView
{
    [Key]
    public int EtEventId { get; set; } = 0;
    public string EtBezeichnung { get; set; } = string.Empty;
    public string EvEvVeranstalter { get; set; } = string.Empty;
    public string EkEvKategorie { get; set; } = string.Empty;
}