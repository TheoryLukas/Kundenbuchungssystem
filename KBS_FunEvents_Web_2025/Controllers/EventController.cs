using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KBS_FunEvents_Web_2025.Models.ViewModels;
using KBS_Web.Models;

namespace KBS_FunEvents_Web_2025.Controllers
{
    public class EventController : Controller
    {

        private readonly kbsContext _dbContext;

        public EventController(kbsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Details()
        {
            return View("Details");
        }
    }
}