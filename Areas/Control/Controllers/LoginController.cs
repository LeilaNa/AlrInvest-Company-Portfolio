using AlrInvestSupply.Models;
using AlrInvestSupply.Models.Entity;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AlrInvestSupply.Areas.Control.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Control/Login
        AlrDbContext db = new AlrDbContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
         public ActionResult Index(string email, string password)
        {
            if (email == null)
            {
                ViewBag.LoginError = "Zəhmət olmasa e-poçt ünvanınızı yazın";
                return View();
            }
            if (password == null)
            {
                ViewBag.LoginError = "Zəhmət olmasa şifrənizi yazın";
                return View();
            }
            Admin LoggedAdmin = db.Admin.Where(a => a.Email == email).FirstOrDefault();
            if (LoggedAdmin != null && Crypto.VerifyHashedPassword(LoggedAdmin.Password, password))
            {
                Session[SessionKey.AdminSession] = LoggedAdmin;
                Session[SessionKey.AdminName] = LoggedAdmin.Email;
                return RedirectToAction("Index","Slogans") ;
            }
            ViewBag.LoginError = "E-poçt ünvanınız və ya şifrə yalnışdır";
            return View();

           
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

    }
}