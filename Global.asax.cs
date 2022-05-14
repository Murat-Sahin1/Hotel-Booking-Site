using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Hotel_Booking_Site
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_start(object sender, EventArgs e)
        {
            int online_uye_sayisi = Convert.ToInt32(Application["OnlineUyeSayisi"]);
            online_uye_sayisi += 1;
            Application["OnlineUyeSayisi"] = online_uye_sayisi;
        }

        protected void Session_end(object sender, EventArgs e)
        {
            int online_uye_sayisi = Convert.ToInt32(Application["OnlineUyeSayisi"]);
            online_uye_sayisi -= 1;
            Application["OnlineUyeSayisi"] = online_uye_sayisi;

        }
    }
}
