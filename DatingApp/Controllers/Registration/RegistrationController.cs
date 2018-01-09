using DatingApp.Models.Extensions.NameValueCollectionExtensions;
using DatingApp.Models.Infrastructure.ErrorHandling;
using DatingApp.Models.User.Profile.Registration;
using System.Web;
using System.Web.Mvc;

namespace DatingApp.Controllers.Registration
{
    public class RegistrationController : Controller
    {
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Register()
        {
            UserRegistration newRegistration = new UserRegistration();

            newRegistration.Username = HttpUtility.HtmlEncode(Request.Form["username"]);
            newRegistration.Password = HttpUtility.HtmlEncode(Request.Form["password"]);
            newRegistration.Email = HttpUtility.HtmlEncode(Request.Form["email"]);

            int s;
            int.TryParse(HttpUtility.HtmlEncode(Request.Form["sex"]), out s);
            newRegistration.Sex = s;

            int.TryParse(HttpUtility.HtmlEncode(Request.Form["day"]), out newRegistration.Day);
            int.TryParse(HttpUtility.HtmlEncode(Request.Form["month"]), out newRegistration.Month);
            int.TryParse(HttpUtility.HtmlEncode(Request.Form["year"]), out newRegistration.Year);

            int c;
            int.TryParse(HttpUtility.HtmlEncode(Request.Form["country"]), out c);
            newRegistration.Country = c;

            try
            {
                newRegistration.Create();
            }
            catch (RuleException e)
            {
                System.Web.HttpContext.Current.Session["___inputForm"] = newRegistration;
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("ConfirmYourEmailAddress", "registration");

        }


        public ActionResult ConfirmYourEmailAddress()
        {
            return View("Index");
        }

        public ActionResult GoEmailGo(string es)
        {


            return RedirectToAction("EmailVerified");
        }

        public ActionResult EmailVerified()
        {
            return View("emailconfirmed");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult stepone()
        {
            RegistrationProfileVersionOne f = new RegistrationProfileVersionOne();
            f.Get();

            return View("formone", f);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult stepone(RegistrationProfileVersionOne f)
        {
            try
            {
                f.Set();
            }
            catch (RuleException e)
            {
                f.Errors.CopyToModelState(ModelState);
                return View("formone", f);
            }

            return RedirectToAction("steptwo", "registration");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult steptwo()
        {
            RegistrationProfileVersionTwo f = new RegistrationProfileVersionTwo();
            f.Get();

            return View("formtwo", f);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult steptwo(RegistrationProfileVersionTwo f)
        {
            try
            {
                f.Set();
            }
            catch (RuleException e)
            {
                f.Errors.CopyToModelState(ModelState);
                return View("formtwo", f);
            }

            return RedirectToAction("laststep", "registration");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult laststep()
        {
            RegistrationProfileVersionThree f = new RegistrationProfileVersionThree();
            f.Get();

            return View("laststep", f);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult laststep(RegistrationProfileVersionThree f)
        {
            try
            {
                f.Set();
            }
            catch (RuleException e)
            {
                f.Errors.CopyToModelState(ModelState);
                return View("laststep", f);
            }

            return View("laststep", f);
        }
    }
}