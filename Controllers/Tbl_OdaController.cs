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
    public class Tbl_OdaController : Controller
    {
        private My_HotelEntities db = new My_HotelEntities();

        // GET: Tbl_Oda
        public ActionResult Index()
        {
            return View(db.Tbl_Oda.ToList());
        }
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Tbl_Oda obj_oda)
        {
            int id = obj_oda.OdaID;
            return RedirectToAction("Rezervasyon_Ekrani", id);
        }
        */
        public ActionResult Rezervasyon_Ekrani(int? id)
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
            var model = tbl_Oda;
            return View(model);
        }

        // GET: Tbl_Oda/Details/5
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

        // GET: Tbl_Oda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Oda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OdaID,OdaTip,OdaKisiLimit,OdaGenislik")] Tbl_Oda tbl_Oda)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Oda.Add(tbl_Oda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Oda);
        }

        // GET: Tbl_Oda/Edit/5
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
            return View(tbl_Oda);
        }

        // POST: Tbl_Oda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OdaID,OdaTip,OdaKisiLimit,OdaGenislik")] Tbl_Oda tbl_Oda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Oda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Oda);
        }

        // GET: Tbl_Oda/Delete/5
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

        // POST: Tbl_Oda/Delete/5
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
        public ActionResult OdaID(int id)
        {
            string OdemeFiyat = (from k in db.Tbl_Odeme
                            where k.OdaID == id
                            select k.OdemeFiyat).FirstOrDefault();

            ViewBag.Title = OdemeFiyat + " seçilen odanın fiyatı.";
            ViewBag.Id = id;
            List<Tbl_Oda> buFiyattakiOdalar = (from u in db.Tbl_Oda
                                                 where u.OdaID == id
                                                 select u).ToList();

            return View(buFiyattakiOdalar);

        }
        public ActionResult Detay(int id)
        {
            Tbl_Oda my_oda = (from u in db.Tbl_Oda
                              where u.OdaID == id
                              select u).FirstOrDefault();

            return View(my_oda);
        }
    }
}
