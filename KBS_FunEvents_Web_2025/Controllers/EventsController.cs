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

        // GET: EventsController
        public ActionResult Index()
        {
            List<TblEvVeranstalter> veranstalter = _dbContext.TblEvVeranstalters.ToList();
            List<TblEvKategorie> kategorien = _dbContext.TblEvKategories.ToList();
            List<TblEvent> events = _dbContext.TblEvents.ToList();
            
            return View("Views/Events/Events.cshtml", events);
        }
    }
}
