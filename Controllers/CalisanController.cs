using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel_Booking_Site.Models;
using System.Linq.Dynamic.Core;


namespace Hotel_Booking_Site.Controllers
{
    public class CalisanController : Controller
    {
        // GET: Calisan
        public ActionResult Index( string sort ="CalisanIsim", string sortdir = "asc", string search = "")
        {
            int totalRecord = 0;
            var data = GetCalisan(search, sort, sortdir, out totalRecord);
            ViewBag.TotalRecord = totalRecord;
            ViewBag.search = search;
            return View(data);
        }
        public ActionResult List()
        {
            var calisan = new List<Tbl_Calisan>();
            using (My_HotelEntities db = new My_HotelEntities())
            {
                calisan = db.Tbl_Calisan.ToList();
            }
            return View(calisan);
        }
        public List<Tbl_Calisan> GetCalisan(string search, string sort, string sortdir, out
int totalRecord)

        {
            //burada AlbümEntities veritabanı içeriğini oluşturmaktadır
            using (My_HotelEntities db = new My_HotelEntities())
            {
                var v = (from a in db.Tbl_Calisan

                         where a.CalisanIsim.Contains(search) ||
                         a.CalisanPozisyon.Contains(search) ||
                         a.CalisanMusait.Contains(search) ||
                         a.CalisanSoyisim.Contains(search) ||
                         a.CalisanUyruk.Contains(search)

                         select a
                ); //Filtreleme metodu

                totalRecord = v.Count();
                v = v.OrderBy(sort + " " + sortdir);
                return v.ToList();
            }
            
        }
    }
}