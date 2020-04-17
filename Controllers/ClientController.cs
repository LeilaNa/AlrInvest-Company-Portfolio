using AlrInvestSupply.Models;
using System.Linq;
using System.Web.Mvc;

namespace AlrInvestSupply.Controllers
{
    public class ClientController : Controller
    {
        AlrDbContext db = new AlrDbContext();
        // GET: Client
        public ActionResult Index()
        {
            var clients = db.Clients.ToList();
            return View(clients);
        }
    }
}