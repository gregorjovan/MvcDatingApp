using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;


namespace DatingApp.Controllers.Users
{
    public class UsersController : Controller
    {

        public ActionResult show(string username)
        {
            ViewData["name"] = username;
            return View();
        }
    }
}