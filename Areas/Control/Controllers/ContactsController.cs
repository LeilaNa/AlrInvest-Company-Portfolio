using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AlrInvestSupply.Models;
using AlrInvestSupply.Models.Entity;

namespace AlrInvestSupply.Areas.Control.Controllers
{
    [AuthorizeAdminFilter]
    public class ContactsController : Controller
    {
        private AlrDbContext db = new AlrDbContext();

        // GET: Control/Contacts
        public ActionResult Index()
        {
            return View(db.Contact.ToList());
        }

        // GET: Control/Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Control/Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Phone,Adress,Email")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
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
