using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KBS_FunEvents_Web_2025.Models.ViewModels;
using KBS_Web.Models;

namespace KBS_FunEvents_Web_2025.Controllers
{
    public class BuchungController : Controller
    {

        private readonly kbsContext _dbContext;

        public BuchungController(kbsContext DbContext)
        {
            _dbContext = DbContext;
        }
        public IActionResult Details()
        {
            return View("Details");
        }
    }
}
