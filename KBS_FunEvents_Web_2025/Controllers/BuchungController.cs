using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KBS_FunEvents_Web_2025.Models.ViewModels;
using KBS_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace KBS_FunEvents_Web_2025.Controllers
{
    public class BuchungController : Controller
    {

        private readonly kbsContext _dbContext;

        public BuchungController(kbsContext DbContext)
        {
            _dbContext = DbContext;
        }
        public IActionResult Details(int? edId, int? kuId)
        {
            if (HttpContext.Session.GetInt32("KundenId") != null) {
                DetailsViewModel m = new DetailsViewModel();
                var events = _dbContext.TblEvents.Include(t => t.EkEvKategorie).Include(t => t.EvEvVeranstalter).ToList();
                var ev = events.FirstOrDefault(e => e.EtEventId == edId);
                var ed = _dbContext.TblEventDatens.FirstOrDefault(e => e.EdEvDatenId == edId);

                m.EtBezeichnung = ev.EtBezeichnung;
                m.EtBeschreibung = ev.EtBeschreibung;

                m.EvFirma = ev.EvEvVeranstalter.EvFirma;
                m.EkKatBezeichnung = ev.EkEvKategorie.EkKatBezeichnung;

                m.EdBeginn = ed.EdBeginn;
                m.EdEnde = ed.EdEnde;
                m.EdStartOrt = ed.EdStartOrt;
                m.EdZielort = ed.EdZielort;
                m.EdAktTeilnehmer = ed.EdAktTeilnehmer;
                m.EdPreis = ed.EdPreis;

                return View(m);
            }
            else
            {
                return new StatusCodeResult(403);
            }
            

        }
    }
}