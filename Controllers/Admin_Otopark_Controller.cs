using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel_Booking_Site.Models;

namespace Hotel_Booking_Site.Controllers
{
    public class Admin_Otopark_Controller : Controller
    {
        private My_HotelEntities db = new My_HotelEntities();

        // GET: Admin_Otopark_
        public ActionResult Index()
        {
            var tbl_Otopark = db.Tbl_Otopark.Include(t => t.Tbl_Oda);
            return View(tbl_Otopark.ToList());
        }

        // GET: Admin_Otopark_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Otopark tbl_Otopark = db.Tbl_Otopark.Find(id);
            if (tbl_Otopark == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Otopark);
        }

        // GET: Admin_Otopark_/Create
        public ActionResult Create()
        {
            ViewBag.OtoparkID = new SelectList(db.Tbl_Oda, "OdaID", "OdaTip");
            return View();
        }

        // POST: Admin_Otopark_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OtoparkID,OdaID")] Tbl_Otopark tbl_Otopark)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Otopark.Add(tbl_Otopark);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OtoparkID = new SelectList(db.Tbl_Oda, "OdaID", "OdaTip", tbl_Otopark.OtoparkID);
            return View(tbl_Otopark);
        }

        // GET: Admin_Otopark_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Otopark tbl_Otopark = db.Tbl_Otopark.Find(id);
            if (tbl_Otopark == null)
            {
                return HttpNotFound();
            }
            ViewBag.OtoparkID = new SelectList(db.Tbl_Oda, "OdaID", "OdaTip", tbl_Otopark.OtoparkID);
            return View(tbl_Otopark);
        }

        // POST: Admin_Otopark_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OtoparkID,OdaID")] Tbl_Otopark tbl_Otopark)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Otopark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OtoparkID = new SelectList(db.Tbl_Oda, "OdaID", "OdaTip", tbl_Otopark.OtoparkID);
            return View(tbl_Otopark);
        }

        // GET: Admin_Otopark_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Otopark tbl_Otopark = db.Tbl_Otopark.Find(id);
            if (tbl_Otopark == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Otopark);
        }

        // POST: Admin_Otopark_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Otopark tbl_Otopark = db.Tbl_Otopark.Find(id);
            db.Tbl_Otopark.Remove(tbl_Otopark);
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
