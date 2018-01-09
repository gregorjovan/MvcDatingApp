using DatingApp.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DatingApp.Models.Search;

namespace DatingApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterRoutes(RouteTable.Routes);
            //SearchCacheEngine.InitializeSearchCache();
        }

        void Session_Start(object sender, EventArgs e)
        {


            HttpContext.Current.Session["___LCID"] = HttpContext.Current.Session.LCID.ToString();
            //Application Culture
            HttpContext.Current.Session["___APPCU"] = UserHelper.Culture_GetFromLCID();
            HttpContext.Current.Session["_u__USERID"] = 77;

            OnlineUser u = new OnlineUser();
            u.Sex = 1;
            u.SeekSex = 2;
            u.Country = 1;
            HttpContext.Current.Session["_u__OUSER"] = u;

        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "users",                                                    // Route name
                "users/{username}",                                        // URL with parameters
                new { controller = "users", action = "show" }      // Parameter defaults
            );
            /*
            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }    // Parameter defaults
            );
            */
        }
    }
}
