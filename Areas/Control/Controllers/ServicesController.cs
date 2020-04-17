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
    public class ServicesController : Controller
    {
        private AlrDbContext db = new AlrDbContext();

        // GET: Control/Services
        public ActionResult Index()
        {
            var services = db.Services.Include(s => s.Language);
            return View(services.ToList());
        }


        // GET: Control/Services/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Language, "Id", "Name");
            return View();
        }

        // POST: Control/Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,MediaUrl,LanguageId")] Services services,HttpPostedFileBase mediaUrl)
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
                services.MediaUrl = mediaUrl.SaveImage(Server.MapPath("~/media"));
                db.Services.Add(services);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Language, "Id", "Name", services.LanguageId);
            return View(services);
        }

        // GET: Control/Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = db.Services.Find(id);
            if (services == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Language, "Id", "Name", services.LanguageId);
            return View(services);
        }

        // POST: Control/Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,MediaUrl,LanguageId")] Services services, HttpPostedFileBase mediaUrl, string fileName)
        {
            Services entity = db.Services.Find(services.Id);
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
                        services.MediaUrl = mediaUrl.SaveImage(Server.MapPath("~/media"));
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
                entity.LanguageId = services.LanguageId;
                entity.Name = services.Name;
                entity.Description = services.Description;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Language, "Id", "Name", services.LanguageId);
            return View(services);
        }

        // GET: Control/Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = db.Services.Find(id);
            if (services == null)
            {
                return HttpNotFound();
            }
            return View(services);
        }

        // POST: Control/Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Services services = db.Services.Find(id);
            db.Services.Remove(services);
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
