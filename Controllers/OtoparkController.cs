using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel_Booking_Site.Models;

namespace Hotel_Booking_Site.Controllers
{
    public class OtoparkController : Controller
    {
        // GET: Otopark
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var otopark = new List<Tbl_Otopark>();
            using(My_HotelEntities db = new My_HotelEntities())
            {
                otopark = db.Tbl_Otopark.ToList();
            }
            return View(otopark);
        }
    }
}