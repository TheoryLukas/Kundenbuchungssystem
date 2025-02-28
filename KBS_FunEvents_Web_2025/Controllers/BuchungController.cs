using Microsoft.AspNetCore.Mvc;

namespace KBS_FunEvents_Web_2025.Controllers
{
    public class BuchungController : Controller
    {
        public IActionResult Details()
        {
            return View("Details");
        }
    }
}
