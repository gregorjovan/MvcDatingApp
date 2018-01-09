using DatingApp.Models.Extensions.NameValueCollectionExtensions;
using DatingApp.Models.Infrastructure.ErrorHandling;
using DatingApp.Models.User.Profile.Properties;
using System.Web.Mvc;

namespace DatingApp.Controllers.Profile
{
    public class ProfileController : Controller
        {

            [AcceptVerbs(HttpVerbs.Get)]
            public ActionResult Basic()
            {
                Basic f = new Basic();
                f.Get();

                return View("Basic", f);
            }

            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult basic(Basic f)
            {
                try
                {
                    f.Set();
                }
                catch (RuleException e)
                {
                    f.Errors.CopyToModelState(ModelState);
                }

                return View("basic", f);
            }

            [AcceptVerbs(HttpVerbs.Get)]
            public ActionResult lifestyle()
            {
                Lifestyle f = new Lifestyle();
                f.Get();

                return View("lifestyle", f);
            }

            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult lifestyle(Lifestyle f)
            {
                try
                {
                    f.Set();
                }
                catch (RuleException e)
                {
                    f.Errors.CopyToModelState(ModelState);
                }

                return View("lifestyle", f);
            }

            [AcceptVerbs(HttpVerbs.Get)]
            public ActionResult interests()
            {
                Interests f = new Interests();
                f.Get();

                return View("interests", f);
            }

            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult interests(Interests f)
            {
                try
                {
                    f.Set();
                }
                catch (RuleException e)
                {
                    f.Errors.CopyToModelState(ModelState);
                }

                return View("interests", f);
            }

            [AcceptVerbs(HttpVerbs.Get)]
            public ActionResult appearance()
            {
                Appearance f = new Appearance();
                f.Get();

                return View("appearance", f);
            }

            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult appearance(Appearance f)
            {
                try
                {
                    f.Set();
                }
                catch (RuleException e)
                {
                    f.Errors.CopyToModelState(ModelState);
                }

                return View("appearance", f);
            }

            [AcceptVerbs(HttpVerbs.Get)]
            public ActionResult values()
            {
                Values f = new Values();
                f.Get();

                return View("values", f);
            }

            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult values(Values f)
            {
                try
                {
                    f.Set();
                }
                catch (RuleException e)
                {
                    f.Errors.CopyToModelState(ModelState);
                }

                return View("values", f);
            }

            [AcceptVerbs(HttpVerbs.Get)]
            public ActionResult welcomemessage()
            {
                WelcomeMessage f = new WelcomeMessage();
                f.Get();

                return View("welcomemessage", f);
            }

            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult welcomemessage(WelcomeMessage f)
            {
                try
                {
                    f.Set();
                }
                catch (RuleException e)
                {
                    f.Errors.CopyToModelState(ModelState);
                }

                return View("welcomemessage", f);
            }

            [AcceptVerbs(HttpVerbs.Get)]
            public ActionResult personal()
            {
                PersonalDescription f = new PersonalDescription();
                f.Get();

                return View("personal", f);
            }

            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult personal(PersonalDescription f)
            {
                try
                {
                    f.Set();
                }
                catch (RuleException e)
                {
                    f.Errors.CopyToModelState(ModelState);
                }

                return View("personal", f);
            }

            [AcceptVerbs(HttpVerbs.Get)]
            public ActionResult tellmore()
            {
                TellMore f = new TellMore();
                f.Get();

                return View("tellmore", f);
            }

            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult tellmore(TellMore f)
            {
                try
                {
                    f.Set();
                }
                catch (RuleException e)
                {
                    f.Errors.CopyToModelState(ModelState);
                }

                return View("tellmore", f);
            }

        }    
}