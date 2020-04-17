using AlrInvestSupply.Models;
using AlrInvestSupply.Models.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AlrInvestSupply.Controllers
{
    public class ServiceController : Controller
    {

        private AlrDbContext db = new AlrDbContext();
        // GET: Services
        public ActionResult Index()
        {
            List<Services> serv;
            if (Extension.CurrentCulture=="en")
            {
                serv = db.Services.Where(s => s.LanguageId == 1).ToList();
            }
            else 
            {
                serv = db.Services.Where(s => s.LanguageId == 1).ToList();
            }
            return View(serv);
        }
    }
}