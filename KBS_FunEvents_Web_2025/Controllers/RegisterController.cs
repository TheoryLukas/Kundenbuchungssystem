using KBS_FunEvents_Web_2025.ComputeHash;
using KBS_FunEvents_Web_2025.ViewModels;
using KBS_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KBS_FunEvents_Web_2025.Controllers
{
    public class RegisterController : Controller
    {

        private readonly kbsContext _dbContext;
        public RegisterController(kbsContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Views/Register/Register.cshtml");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Views/Register/Register.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModelView register)
        {

            if (ModelState.IsValid)
            {
                var nachname = register.kdNachname;
                var vorname = register.kdVorname;
                var strasse = register.kdStrasse;
                var hNummer = register.kdHNummer;
                var plz = register.kdPLZ;
                var ort = register.kdOrt;
                var telefon = register.kdTelefon;
                var email = register.kdEmail;
                var emailRepeat = register.kdEmailRepeat;
                var password = register.kdPwHash;
                var passwordRepeat = register.kdEmailRepeat;

                TblKunden customer = await _dbContext.TblKundens.FirstOrDefaultAsync(x => x.KdEmail == email);
                
                
                if (customer == null)
                {
                    customer = new TblKunden();
                    customer.KdName = nachname;
                    customer.KdVorname = vorname;
                    customer.KdStrasse = strasse;
                    customer.KdHnummer = hNummer;
                    customer.KdPlz = plz;
                    customer.KdOrt = ort;
                    customer.KdTelefon = telefon;
                    customer.KdEmail = email;
                    customer.KdPasswortHash = MD5Generator.getMD5Hash(password);
                    _dbContext.TblKundens.Add(customer);
                    _dbContext.SaveChanges();

                    return RedirectToAction("Index","Login");
                } else
                {

                    ModelState.AddModelError("kdEmail", "Account existiert bereits");
                    TempData["error"] = "Account existiert bereits";
                    return Index();
                }

            }
            return Index();
        }

    }
}
