using AlrInvestSupply.Models;
using System.Linq;
using System.Web.Mvc;

namespace AlrInvestSupply.Controllers
{
    public class ContactController : Controller
    {
        AlrDbContext db = new AlrDbContext();
        // GET: Contact
        public ActionResult Index()
        {
          
            return View(db.Contact.FirstOrDefault());
        }
    }
}