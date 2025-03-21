using KBS_FunEvents_Web_2025.ViewModels;
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

        private List<EventModelView> GetActiveEvents()
        {
            _ = _dbContext.TblEvVeranstalters.ToList();
            _ = _dbContext.TblEvKategories.ToList();

            List<int> activeEventIDs = _dbContext.TblEventDatens.ToList()
                                        .Where(ed => ed.EdFreigegeben == true)
                                        .DistinctBy(ed => ed.EtEventId)
                                        .Select(ed => ed.EtEventId).ToList();

            List<TblEvent> activeEvents = _dbContext.TblEvents.ToList()
                                        .Where(ev => activeEventIDs.Contains(ev.EtEventId)).ToList();

            List<EventModelView> eventModelView = [];

            activeEvents.ForEach(delegate(TblEvent tblEvent)
            {
                eventModelView.Add(new EventModelView
                {
                    EtEventId = tblEvent.EtEventId,
                    EtBezeichnung = tblEvent.EtBezeichnung,
                    EkEvKategorie = tblEvent.EkEvKategorie.EkKatBezeichnung,
                    EvEvVeranstalter = tblEvent.EvEvVeranstalter.EvFirma
                });
            });

            return eventModelView;
        }

        // GET: EventsController
        public ActionResult Index()
        {            
            return View("Views/Events/Events.cshtml", GetActiveEvents());
        }

        public ActionResult Details(int eventId)
        {
            return View("Views/Events/EventDaten.cshtml");
        }
    }
}
