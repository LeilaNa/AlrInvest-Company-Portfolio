using AlrInvestSupply.Models;
using AlrInvestSupply.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AlrInvestSupply.Controllers
{
    public class AboutController : Controller
    {
        AlrDbContext db = new AlrDbContext();
        // GET: About
        public ActionResult Index()
        {
            About about;
            if (Extension.CurrentCulture=="az")
            {
                about = db.About.Where(a => a.LanguageId == 2).FirstOrDefault();
            }
            else 
            {
                about = db.About.Where(a => a.LanguageId == 1).FirstOrDefault();
            }
            return View(about);
        }
    }
}