using DatingApp.Models.Extensions.NameValueCollectionExtensions;
using DatingApp.Models.User.Profile.Registration;
using System.Web.Mvc;

namespace DatingApp.Controllers.Home
{
    [HandleError]
    public class HomeController : Controller
    {
        private UserRegistration userData;

        public ActionResult Index()
        {
            userData = new UserRegistration();
            if (System.Web.HttpContext.Current.Session["___inputForm"] != null)
            {
                userData = (UserRegistration)System.Web.HttpContext.Current.Session["___inputForm"];

                userData.Errors.CopyToModelState(ModelState);
                System.Web.HttpContext.Current.Session.Remove("___inputForm");
            }



            return View(userData);
        }
    }
}