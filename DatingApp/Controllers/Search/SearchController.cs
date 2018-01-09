using DatingApp.Models.Infrastructure;
using DatingApp.Models.Search;
using System;
using System.Web;
using System.Web.Mvc;

namespace DatingApp.Controllers.Search
{
    public class SearchController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult index()
        {
            return Basic(new BasicSearch());
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Basic(BasicSearch f)
        {
            OnlineUser u = (OnlineUser)System.Web.HttpContext.Current.Session["_u__OUSER"];

            if (u != null)
            {
                if (f.Sex == 0)
                    f.Sex = u.Sex;
                if (f.SeekSex == 0)
                    f.SeekSex = u.SeekSex;
                if (f.Country == 0)
                    f.Country = u.Country;
            }

            HttpCookie newCookie = new HttpCookie("counter");
            newCookie.Expires = DateTime.Now.AddDays(-1);
            Response.AppendCookie(newCookie);

            return View("BasicSearch", f);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Advanced(AdvancedSearch f)
        {
            OnlineUser u = (OnlineUser)System.Web.HttpContext.Current.Session["_u__OUSER"];

            if (u != null)
            {
                if (f.Sex == 0)
                    f.Sex = u.Sex;
                if (f.SeekSex == 0)
                    f.SeekSex = u.SeekSex;
                if (f.Country == 0)
                    f.Country = u.Country;
            }

            HttpCookie newCookie = new HttpCookie("counter");
            newCookie.Expires = DateTime.Now.AddDays(-1);
            Response.AppendCookie(newCookie);

            return View("AdvancedSearch", f);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult results(BasicSearch f)
        {
            int[] r;
            r = f.GetResults(true);

            //if (f.Page == 1 || Request.Cookies["counter"] == null)
            //{



            //    HttpCookie newCookie = new HttpCookie("counter", counter.ToString());
            //    newCookie.Expires = DateTime.Now.AddDays(1);
            //    Response.AppendCookie(newCookie);

            //}
            //else
            //{
            //    r = SearchEngine.results(f.AgeMin, f.AgeMax, 5, f.Sign, f.Ethnicity, 70, f.Page, out speed); 
            //    //r = f.GetResults(false).ToArray();
            //    Int32.TryParse(Request.Cookies["counter"].Value, out counter);
            //}

            return View("results", r);
        }
    }
}