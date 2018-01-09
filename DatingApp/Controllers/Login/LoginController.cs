using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;


namespace DatingApp.Controllers.Login
{
    public class LoginController : Controller
    {
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult login(FormCollection collection)
        {
            return RedirectToAction("Index", "Home");

        }
    }
}