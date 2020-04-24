using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Great_Groomer.Database;
using Great_Groomer.Models;

namespace Great_Groomer.Controllers
{
    public class GroomBookingsController : Controller
    {
        private GreatGroomerDbContext db = new GreatGroomerDbContext();

        // GET: GroomBookings
        public ActionResult Index()
        {
            var groomBookings = db.GroomBookings.Include(g => g.Groomer).Include(g => g.GroomService).Include(g => g.Owner).Include(g => g.Pet);
            return View(groomBookings.ToList());
        }

        // GET: GroomBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroomBooking groomBooking = db.GroomBookings.Find(id);
            if (groomBooking == null)
            {
                return HttpNotFound();
            }
            return View(groomBooking);
        }

        // GET: GroomBookings/Create
        public ActionResult Create()
        {
            ViewBag.GroomerID = new SelectList(db.Groomers, "GroomerID", "FirstName");
            ViewBag.GroomServiceID = new SelectList(db.GroomServices, "GroomServiceID", "ServiceName");
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "FirstName");
            ViewBag.PetID = new SelectList(db.Pets, "PetId", "Name");
            return View();
        }

        // POST: GroomBookings/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroomBookingID,GroomBookingDate,PetID,GroomerID,OwnerID,GroomServiceID")] GroomBooking groomBooking)
        {
            if (ModelState.IsValid)
            {
                groomBooking.GroomBookingPrice = db.GroomServices.SingleOrDefault(x => x.GroomServiceID == groomBooking.GroomServiceID).ServiceCost;
                db.GroomBookings.Add(groomBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroomerID = new SelectList(db.Groomers, "GroomerID", "FirstName", groomBooking.GroomerID);
            ViewBag.GroomServiceID = new SelectList(db.GroomServices, "GroomServiceID", "ServiceName", groomBooking.GroomServiceID);
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "FirstName", groomBooking.OwnerID);
            ViewBag.PetID = new SelectList(db.Pets, "PetId", "Name", groomBooking.PetID);
            return View(groomBooking);
        }

        // GET: GroomBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroomBooking groomBooking = db.GroomBookings.Find(id);
            if (groomBooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroomerID = new SelectList(db.Groomers, "GroomerID", "FirstName", groomBooking.GroomerID);
            ViewBag.GroomServiceID = new SelectList(db.GroomServices, "GroomServiceID", "ServiceName", groomBooking.GroomServiceID);
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "FirstName", groomBooking.OwnerID);
            ViewBag.PetID = new SelectList(db.Pets, "PetId", "Name", groomBooking.PetID);
            return View(groomBooking);
        }

        // POST: GroomBookings/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroomBookingID,GroomBookingDate,PetID,GroomerID,OwnerID,GroomServiceID")] GroomBooking groomBooking)
        {
            if (ModelState.IsValid)
            {
                groomBooking.GroomBookingPrice = db.GroomServices.SingleOrDefault(x => x.GroomServiceID == groomBooking.GroomServiceID).ServiceCost;
                db.Entry(groomBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroomerID = new SelectList(db.Groomers, "GroomerID", "FirstName", groomBooking.GroomerID);
            ViewBag.GroomServiceID = new SelectList(db.GroomServices, "GroomServiceID", "ServiceName", groomBooking.GroomServiceID);
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "FirstName", groomBooking.OwnerID);
            ViewBag.PetID = new SelectList(db.Pets, "PetId", "Name", groomBooking.PetID);
            return View(groomBooking);
        }

        // GET: GroomBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroomBooking groomBooking = db.GroomBookings.Find(id);
            if (groomBooking == null)
            {
                return HttpNotFound();
            }
            return View(groomBooking);
        }

        // POST: GroomBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroomBooking groomBooking = db.GroomBookings.Find(id);
            db.GroomBookings.Remove(groomBooking);
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
