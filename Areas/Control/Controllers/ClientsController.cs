using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlrInvestSupply.Models;
using AlrInvestSupply.Models.Entity;

namespace AlrInvestSupply.Areas.Control.Controllers
{
    [AuthorizeAdminFilter]
    public class ClientsController : Controller
    {
        private AlrDbContext db = new AlrDbContext();

        // GET: Control/Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        

        // GET: Control/Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Control/Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MediaUrl,Link")] Clients clients, HttpPostedFileBase mediaUrl)
        {
            if (mediaUrl == null)
                ModelState.AddModelError("mediaUrl", "Şəkil seçilməyib!");
            else
            {
                if (!mediaUrl.CheckImageType())
                    ModelState.AddModelError("mediaUrl", "Şəkil uyğun deyil!");
                if (!mediaUrl.CheckImageSize(5))
                    ModelState.AddModelError("mediaUrl", "Şəklin ölçüsü uyğun deyil!");
            }
            if (ModelState.IsValid)
            {
                clients.MediaUrl = mediaUrl.SaveImage(Server.MapPath("~/media"));
                db.Clients.Add(clients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clients);
        }

        // GET: Control/Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        // POST: Control/Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,MediaUrl,Link")] Clients clients, HttpPostedFileBase mediaUrl, string fileName)
        {
            Clients entity = db.Clients.Find(clients.Id);
            if (entity == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ModelState.Remove("mediaUrl");

            if (mediaUrl != null)
            {
                bool valid = true;
                if (!mediaUrl.CheckImageType())
                {
                    ModelState.AddModelError("mediaUrl", "Şəkil uyğun deyil!");
                    valid = false;
                }

                if (!mediaUrl.CheckImageSize(5))
                {
                    ModelState.AddModelError("mediaUrl", "Şəklin ölçüsü uyğun deyil!");
                    valid = false;
                }

                if (valid)
                {
                    string newPath = mediaUrl.SaveImage(Server.MapPath("~/media"));

                    //System.IO.File.Move(Server.MapPath(System.IO.Path.Combine("~/Template/media", entity.MediaUrl)),
                    //    Server.MapPath(System.IO.Path.Combine("~/Template/media", entity.MediaUrl)));

                    if (!string.IsNullOrWhiteSpace(entity.MediaUrl))
                    {
                        clients.MediaUrl = mediaUrl.SaveImage(Server.MapPath("~/media"));
                    }
                    entity.MediaUrl = newPath;

                }
            }
            else if (!string.IsNullOrWhiteSpace(entity.MediaUrl)
                && string.IsNullOrWhiteSpace(fileName))
            {
                entity.MediaUrl = null;
            }
            if (ModelState.IsValid)
            {
                //entity.MediaUrl = mediaUrl.SaveImage(Server.MapPath("~/media"));
                entity.Name = clients.Name;
                entity.Link = clients.Link;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(clients);
        }

        // GET: Control/Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        // POST: Control/Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clients clients = db.Clients.Find(id);
            db.Clients.Remove(clients);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
