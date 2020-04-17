using AlrInvestSupply.Models;
using System.Linq;
using System.Web.Mvc;

namespace AlrInvestSupply.Controllers
{

    public class HomeController : Controller
    {
        private AlrDbContext db = new AlrDbContext();
        // GET: Home
        public ActionResult Index()
        {
            HomePageViewModel VMen = new HomePageViewModel
            {

                Slogans = db.Slogans.Where(s => s.LanguageId == 1).FirstOrDefault(),
                About = db.About.Where(a => a.LanguageId == 1).FirstOrDefault(),
                Services = db.Services.Where(s => s.LanguageId == 1).ToList(),
                Contact = db.Contact.FirstOrDefault()

            };
            HomePageViewModel VMaz = new HomePageViewModel
            {

                Slogans = db.Slogans.Where(s => s.LanguageId == 2).FirstOrDefault(),
                About = db.About.Where(a => a.LanguageId == 2).FirstOrDefault(),
                Services = db.Services.Where(s => s.LanguageId == 2).ToList(),
                Contact = db.Contact.FirstOrDefault()

            };
            if (Extension.CurrentCulture=="az")
            {
                return View(VMaz);

            }
            else if(Extension.CurrentCulture=="en")
            {
                return View(VMen);

            }
            return View();
        }

        [ChildActionOnly]
        public  ActionResult Footer()
        {
            return View(db.Contact.FirstOrDefault());
        }
    }
}