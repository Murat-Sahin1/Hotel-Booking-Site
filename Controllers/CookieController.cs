using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Booking_Site.Controllers
{
    public class CookieController : Controller
    {
        // GET: Cookie
        public ActionResult OnlineUyeSayisi()
        {
            ViewBag.OnlineUyeSayisi = HttpContext.Application["OnlineUyeSayisi"];
            return View();
        }
        public ActionResult Olustur()
        {
            HttpCookie cookieKullanici = new HttpCookie("kullanici", "zeynep");
            HttpContext.Response.Cookies.Add(cookieKullanici);
            ViewBag.Kullanici = HttpContext.Response.Cookies["kullanici"].Value;
            return View();
        }

        public ActionResult Sil()
        {
            HttpContext.Request.Cookies.Remove("kullanici");
            return View();
        }
    }
}