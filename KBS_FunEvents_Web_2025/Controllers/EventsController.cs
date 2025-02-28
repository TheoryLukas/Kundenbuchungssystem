using KBS_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace KBS_FunEvents_Web_2025.Controllers
{
    public class EventsController : Controller
    {
        private readonly kbsContext _dbContext;

        public EventsController(kbsContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Alle Events mit mindestens einem freigebenem EveentDaten-Eintrag
        private List<TblEvent> GetEvents()
        {
            _ = _dbContext.TblEvVeranstalters.ToList();
            _ = _dbContext.TblEvKategories.ToList();
            
            List<int> activeEvents = _dbContext.TblEventDatens.ToList()
                                        .Where(ed => ed.EdFreigegeben == true)
                                        .DistinctBy(ed => ed.EtEventId)
                                        .Select(ed => ed.EtEventId).ToList();
            
            List<TblEvent> events = _dbContext.TblEvents.ToList()
                                        .Where(ev => activeEvents.Contains(ev.EtEventId)).ToList();

            return events;
        }

        // GET: EventsController
        public ActionResult Index()
        {
            return View("Views/Events/Events.cshtml", GetEvents());
        }

        public ActionResult Details(int eventId)
        {
            return View("Views/Events/EventDaten.cshtml");
        }
    }
}
