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
    public class GroomServicesController : Controller
    {
        private GreatGroomerDbContext db = new GreatGroomerDbContext();

        // GET: GroomServices
        public ActionResult Index()
        {
            return View(db.GroomServices.ToList());
        }

        // GET: GroomServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroomService groomService = db.GroomServices.Find(id);
            if (groomService == null)
            {
                return HttpNotFound();
            }
            return View(groomService);
        }

        // GET: GroomServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroomServices/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroomServiceID,ServiceName,ServiceCost,ServiceDuration")] GroomService groomService)
        {
            if (ModelState.IsValid)
            {
                db.GroomServices.Add(groomService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groomService);
        }

        // GET: GroomServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroomService groomService = db.GroomServices.Find(id);
            if (groomService == null)
            {
                return HttpNotFound();
            }
            return View(groomService);
        }

        // POST: GroomServices/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroomServiceID,ServiceName,ServiceCost,ServiceDuration")] GroomService groomService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groomService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groomService);
        }

        // GET: GroomServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroomService groomService = db.GroomServices.Find(id);
            if (groomService == null)
            {
                return HttpNotFound();
            }
            return View(groomService);
        }

        // POST: GroomServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroomService groomService = db.GroomServices.Find(id);
            db.GroomServices.Remove(groomService);
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
