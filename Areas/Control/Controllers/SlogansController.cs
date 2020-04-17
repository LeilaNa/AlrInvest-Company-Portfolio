using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AlrInvestSupply.Models;
using AlrInvestSupply.Models.Entity;

namespace AlrInvestSupply.Areas.Control.Controllers
{
    [AuthorizeAdminFilter]
    public class SlogansController : Controller
    {
        private AlrDbContext db = new AlrDbContext();

        // GET: Control/Slogans
        public ActionResult Index()
        {
            var slogans = db.Slogans.Include(s => s.Language);
            return View(slogans.ToList());
        }

      
        // GET: Control/Slogans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slogans slogans = db.Slogans.Find(id);
            if (slogans == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Language, "Id", "Name", slogans.LanguageId);
            return View(slogans);
        }

        // POST: Control/Slogans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BigSlogan,SmallSlogan,LanguageId")] Slogans slogans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slogans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Language, "Id", "Name", slogans.LanguageId);
            return View(slogans);
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
