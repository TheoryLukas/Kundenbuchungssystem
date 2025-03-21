using KBS_FunEvents_Web_2025.ViewModels;
using KBS_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Security.Cryptography;

namespace KBS_FunEvents_Web_2025.Controllers
{
    public class DashboardController : Controller
    {
        private readonly kbsContext _dbContext;

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("KundenID") == null) return RedirectToAction("Index", "Home");

            var K = getKunde();
            ViewBag.Kunde = K.KdVorname;
            DashboardModelView DashboardView = new DashboardModelView();
            var B = getBeginn();
            DashboardView.ed_Beginn = B.EdBeginn;
            var E = getEvent();
            DashboardView.et_Beschreibung = E.EtBeschreibung;
            DashboardView.et_Bezeichnung = E.EtBezeichnung;
            var DE = getDoneEvents();
            ViewBag.DoneEvents = DE;
            var SB = getStornierteBuchungen();
            ViewBag.StornierteBuchungen = SB;
            var AB = getActiveBookings();
            ViewBag.ActiveBookings = AB;

            return View("Views/Dashboard/Dashboard.cshtml", DashboardView);
        }

        public DashboardController(kbsContext dbContext)
        {
            _dbContext = dbContext;
        }

        private TblKunden getKunde()
        {
            _ = _dbContext.TblKundens.ToList();
            int? kId = HttpContext.Session.GetInt32("KundenID");

            TblKunden Kunde = _dbContext.TblKundens.ToList().Where(k => k.KdKundenId == kId).First();

            return Kunde;
        }

        [HttpGet]
        private TblEventDaten getBeginn()
        {
            TblEventDaten nextEventBeginn = _dbContext.TblEventDatens
                                                .Where(ed => ed.EdBeginn >= DateTime.Today)
                                                .OrderBy(ed => ed.EdBeginn)
                                                .FirstOrDefault();
            if (nextEventBeginn == null)
            {
                nextEventBeginn = _dbContext.TblEventDatens
                                      .Where(ed => ed.EdBeginn < DateTime.Today)
                                      .OrderByDescending(ed => ed.EdBeginn)
                                      .FirstOrDefault();
            }

            return nextEventBeginn;
        }

        [HttpGet]
        private TblEvent getEvent()
        {
            var B = getBeginn();

            TblEvent Bezeichnung = _dbContext.TblEvents
                                             .FirstOrDefault(et => et.EtEventId == B.EtEventId);

            return Bezeichnung;
        }

        [HttpGet]
        private int getDoneEvents()
        {
            int? kId = HttpContext.Session.GetInt32("KundenID");
            if (kId == null)
            {
                return 0;
            }

            var buchungen = _dbContext.TblBuchungens
                .Where(b => b.KdKundenId == kId)
                .ToList();

            int completedEventsCount = 0;

            foreach (var buchung in buchungen)
            {
                var eventDaten = _dbContext.TblEventDatens
                    .FirstOrDefault(ed => ed.EdEvDatenId == buchung.EdEvDatenId && ed.EdEnde < DateTime.Now);

                if (eventDaten != null)
                {
                    completedEventsCount++;
                }
            }

            return completedEventsCount;
        }

        [HttpGet]
        private int getStornierteBuchungen()
        {
            int? kId = HttpContext.Session.GetInt32("KundenID");
            if (kId == null)
            {
                return 0;
            }

            var buchungen = _dbContext.TblBuchungens
                .Where(b => b.KdKundenId == kId && b.BuStorniert == true)
                .ToList();

            int stornierteBuchungenCount = 0;

            foreach (var buchung in buchungen)
            {
                if (stornierteBuchungenCount != null)
                {
                    stornierteBuchungenCount++;
                }
            }

            return stornierteBuchungenCount;
        }

        [HttpGet]
        private int getActiveBookings()
        {
            int? kId = HttpContext.Session.GetInt32("KundenID");
            if (kId == null)
            {
                return 0;
            }

            var buchungen = _dbContext.TblBuchungens
                .Where(b => b.KdKundenId == kId && b.BuStorniert == false)
                .ToList();

            int activeBookingsCount = 0;

            foreach (var buchung in buchungen)
            {
                var eventDaten = _dbContext.TblEventDatens
                    .FirstOrDefault(ed => ed.EdEvDatenId == buchung.EdEvDatenId && ed.EdBeginn > DateTime.Now);

                if (eventDaten != null)
                {
                    activeBookingsCount++;
                }
            }

            return activeBookingsCount;
        }
    }
}
