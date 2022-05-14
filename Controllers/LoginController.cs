﻿using Hotel_Booking_Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Booking_Site.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Post metodu kullanılan her yerde kullanılabilir.
        public ActionResult Login(UserProfile obj_user)
        {
            if (ModelState.IsValid) // Model geçerli mi
            {
                using (db_albumlerEntities db = new db_albumlerEntities())
                {
                    var obj = db.UserProfile.Where(a => a.Username.Equals(obj_user.Username) && a.Password.Equals(obj_user.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserID.ToString();
                        Session["Username"] = obj.Username.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
                
            }
            return View(obj_user);
        }

        public ActionResult UserDashBoard()
        {
            if(Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
}