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
    public class Admin_Oda_Controller : Controller
    {
        private My_HotelEntities db = new My_HotelEntities();

        // GET: Admin_Oda_
        public ActionResult Index()
        {
            var tbl_Oda = db.Tbl_Oda.Include(t => t.Tbl_Otopark);
            return View(tbl_Oda.ToList());
        }

        // GET: Admin_Oda_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Oda tbl_Oda = db.Tbl_Oda.Find(id);
            if (tbl_Oda == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Oda);
        }

        // GET: Admin_Oda_/Create
        public ActionResult Create()
        {
            ViewBag.OdaID = new SelectList(db.Tbl_Otopark, "OtoparkID", "OtoparkID");
            return View();
        }

        // POST: Admin_Oda_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OdaID,OdaTip,OdaKisiLimit,OdaGenislik,OdaDurum")] Tbl_Oda tbl_Oda)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Oda.Add(tbl_Oda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OdaID = new SelectList(db.Tbl_Otopark, "OtoparkID", "OtoparkID", tbl_Oda.OdaID);
            return View(tbl_Oda);
        }

        // GET: Admin_Oda_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Oda tbl_Oda = db.Tbl_Oda.Find(id);
            if (tbl_Oda == null)
            {
                return HttpNotFound();
            }
            ViewBag.OdaID = new SelectList(db.Tbl_Otopark, "OtoparkID", "OtoparkID", tbl_Oda.OdaID);
            return View(tbl_Oda);
        }

        // POST: Admin_Oda_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OdaID,OdaTip,OdaKisiLimit,OdaGenislik,OdaDurum")] Tbl_Oda tbl_Oda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Oda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OdaID = new SelectList(db.Tbl_Otopark, "OtoparkID", "OtoparkID", tbl_Oda.OdaID);
            return View(tbl_Oda);
        }

        // GET: Admin_Oda_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Oda tbl_Oda = db.Tbl_Oda.Find(id);
            if (tbl_Oda == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Oda);
        }

        // POST: Admin_Oda_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Oda tbl_Oda = db.Tbl_Oda.Find(id);
            db.Tbl_Oda.Remove(tbl_Oda);
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
