using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;

namespace Hospital.Controllers
{
    public class SectionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sections
        [Authorize]
        public ActionResult Index()
        {
            var sections = db.Sections.Include(s => s.Patient);
            return View(sections.ToList());
        }

        // GET: Sections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sections sections = db.Sections.Find(id);
            if (sections == null)
            {
                return HttpNotFound();
            }
            return View(sections);
        }

        // GET: Sections/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.PatientID = new SelectList(db.Patients, "id", "name");
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,PatientID,Department")] Sections sections)
        {
            if (ModelState.IsValid)
            {
                db.Sections.Add(sections);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientID = new SelectList(db.Patients, "id", "name", sections.PatientID);
            return View(sections);
        }

        // GET: Sections/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sections sections = db.Sections.Find(id);
            if (sections == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientID = new SelectList(db.Patients, "id", "name", sections.PatientID);
            return View(sections);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,PatientID,Department")] Sections sections)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sections).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientID = new SelectList(db.Patients, "id", "name", sections.PatientID);
            return View(sections);
        }

        // GET: Sections/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sections sections = db.Sections.Find(id);
            if (sections == null)
            {
                return HttpNotFound();
            }
            return View(sections);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sections sections = db.Sections.Find(id);
            db.Sections.Remove(sections);
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
