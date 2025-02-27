using Microsoft.AspNetCore.Mvc;

namespace KBS_FunEvents_Web_2025.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
