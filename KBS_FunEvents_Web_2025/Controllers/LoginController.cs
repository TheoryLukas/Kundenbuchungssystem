using KBS_FunEvents_Web_2025.ComputeHash;
using KBS_FunEvents_Web_2025.ViewModels;
using KBS_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KBS_FunEvents_Web_2025.Controllers
{
    public class LoginController : Controller
    {
        private readonly kbsContext _dbContext;
        public LoginController(kbsContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Views/Login/Login.cshtml");
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View("Views/Home/Index.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModelView login)
        {
            if (ModelState.IsValid)
            {
                var email = login.kdEmail;
                var password = MD5Generator.getMD5Hash(login.kdPwHash);
                TblKunden customer = await _dbContext.TblKundens.FirstOrDefaultAsync(x => x.KdEmail == email && x.KdPasswortHash == password);
                if (customer != null) 
                {
                    HttpContext.Session.SetInt32("KundenID", customer.KdKundenId);
                    HttpContext.Session.SetString("Email", customer.KdEmail);
                    return RedirectToAction(controllerName: "Home", actionName: "Privacy");
                }

            }
            return RedirectToAction();
        }
    }
}
