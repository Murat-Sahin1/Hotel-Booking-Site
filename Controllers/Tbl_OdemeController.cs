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
    public class Tbl_OdemeController : Controller
    {
        private My_HotelEntities db = new My_HotelEntities();

        // GET: Tbl_Odeme
        public ActionResult Index()
        {
            var tbl_Odeme = db.Tbl_Odeme.Include(t => t.Tbl_Oda);
            return View(tbl_Odeme.ToList());
        }

        // GET: Tbl_Odeme/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Odeme tbl_Odeme = db.Tbl_Odeme.Find(id);
            if (tbl_Odeme == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Odeme);
        }

        // GET: Tbl_Odeme/Create
        public ActionResult Create()
        {
            ViewBag.OdaID = new SelectList(db.Tbl_Oda, "OdaID", "OdaTip");
            return View();
        }

        // POST: Tbl_Odeme/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OdemeID,OdaID,OdemeFiyat,OdemeTip")] Tbl_Odeme tbl_Odeme)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Odeme.Add(tbl_Odeme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OdaID = new SelectList(db.Tbl_Oda, "OdaID", "OdaTip", tbl_Odeme.OdaID);
            return View(tbl_Odeme);
        }

        // GET: Tbl_Odeme/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Odeme tbl_Odeme = db.Tbl_Odeme.Find(id);
            if (tbl_Odeme == null)
            {
                return HttpNotFound();
            }
            ViewBag.OdaID = new SelectList(db.Tbl_Oda, "OdaID", "OdaTip", tbl_Odeme.OdaID);
            return View(tbl_Odeme);
        }

        // POST: Tbl_Odeme/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OdemeID,OdaID,OdemeFiyat,OdemeTip")] Tbl_Odeme tbl_Odeme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Odeme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OdaID = new SelectList(db.Tbl_Oda, "OdaID", "OdaTip", tbl_Odeme.OdaID);
            return View(tbl_Odeme);
        }

        // GET: Tbl_Odeme/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Odeme tbl_Odeme = db.Tbl_Odeme.Find(id);
            if (tbl_Odeme == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Odeme);
        }

        // POST: Tbl_Odeme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Odeme tbl_Odeme = db.Tbl_Odeme.Find(id);
            db.Tbl_Odeme.Remove(tbl_Odeme);
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
