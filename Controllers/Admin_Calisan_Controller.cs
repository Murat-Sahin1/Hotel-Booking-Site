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
    public class Admin_Calisan_Controller : Controller
    {
        private My_HotelEntities db = new My_HotelEntities();

        // GET: Admin_Calisan_
        public ActionResult Index()
        {
            return View(db.Tbl_Calisan.ToList());
        }

        // GET: Admin_Calisan_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Calisan tbl_Calisan = db.Tbl_Calisan.Find(id);
            if (tbl_Calisan == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Calisan);
        }

        // GET: Admin_Calisan_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin_Calisan_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CalisanID,CalisanIsim,CalisanSoyisim,CalisanUyruk,CalisanPozisyon,CalisanMusait")] Tbl_Calisan tbl_Calisan)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Calisan.Add(tbl_Calisan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Calisan);
        }

        // GET: Admin_Calisan_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Calisan tbl_Calisan = db.Tbl_Calisan.Find(id);
            if (tbl_Calisan == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Calisan);
        }

        // POST: Admin_Calisan_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CalisanID,CalisanIsim,CalisanSoyisim,CalisanUyruk,CalisanPozisyon,CalisanMusait")] Tbl_Calisan tbl_Calisan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Calisan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Calisan);
        }

        // GET: Admin_Calisan_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Calisan tbl_Calisan = db.Tbl_Calisan.Find(id);
            if (tbl_Calisan == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Calisan);
        }

        // POST: Admin_Calisan_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Calisan tbl_Calisan = db.Tbl_Calisan.Find(id);
            db.Tbl_Calisan.Remove(tbl_Calisan);
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
