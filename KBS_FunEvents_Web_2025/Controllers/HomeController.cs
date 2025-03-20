using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KBS_FunEvents_Web_2025.Models;
using KBS_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace KBS_FunEvents_Web_2025.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly kbsContext _dbContext;

    public HomeController(ILogger<HomeController> logger, kbsContext dbContext)
    {
        _logger = logger;
        this._dbContext = dbContext;
    }

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

    private TblEventDaten GetEventDaten(int eventDatenId)
    {

        TblEventDaten eventDaten = (TblEventDaten)_dbContext.TblEventDatens.Where(ed => ed.EdEvDatenId == eventDatenId);

        return eventDaten;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Informationen()
    {
        return View();
    }

    public IActionResult Kontakt()
    {
        return View();
    }

    public IActionResult NeuesEventFinden()
    {
        return View("Views/Home/NeuesEventFinden.cshtml", GetEvents());
    }
    public IActionResult EventBuchen()
    {
        return View("Views/Home/EventBuchen.cshtml", GetEventDaten(1));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
