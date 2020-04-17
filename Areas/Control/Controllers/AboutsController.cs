using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AlrInvestSupply.Models;
using AlrInvestSupply.Models.Entity;

namespace AlrInvestSupply.Areas.Control.Controllers
{
    [AuthorizeAdminFilter]
    public class AboutsController : Controller
    {
        private AlrDbContext db = new AlrDbContext();

        // GET: Control/Abouts
        public ActionResult Index()
        {
            var about = db.About.Include(a => a.Language);
            return View(about.ToList());
        }

      

        // GET: Control/Abouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.About.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Language, "Id", "Name", about.LanguageId);
            return View(about);
        }

        // POST: Control/Abouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,LanguageId")] About about)
        {
            if (ModelState.IsValid)
            {
                db.Entry(about).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Language, "Id", "Name", about.LanguageId);
            return View(about);
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
