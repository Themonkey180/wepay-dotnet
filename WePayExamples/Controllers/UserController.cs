using System.Web.Mvc;
using WePay;
using WePay.Infrastructure;
using WePay.Entities;
using WePay.User;
using System;

namespace Controllers
{
    [RouteArea("User", AreaPrefix = "user")]
    [Route("{action=index}")]
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.accessToken = WePayConfiguration.GetAccessToken();
            ViewBag.clientId = WePayConfiguration.GetClientId();
            ViewBag.clientSecret = WePayConfiguration.GetClientSecret();
            ViewBag.accountId = WePayConfiguration.GetAccountId();
            return View();
        }

        public ActionResult Get()
        {
            var wePayUserService = new WePay.WePayUserService(Request.Form["accessToken"]);
            var wePayUser = wePayUserService.Get();

            return View(wePayUser);
        }

        public ActionResult Modify()
        {
            var wePayUserService = new WePay.WePayUserService(Request.Form["accessToken"]);
            var wePayUser = wePayUserService.Modify(new UserModifyArguments { CallbackUri = Request.Form["callbackUri"] });

            return View("Get", wePayUser);
        }

        public ActionResult Register()
        {
            long temp;
            long? clientid = null;
            var clientidIn = Request.Form["clientid"];
            if (long.TryParse(clientidIn, out temp)) clientid = temp;
            var clientsecret = Request.Form["clientsecret"];


            var wePayUserService = new WePay.WePayUserService(null, clientid, clientsecret);
            var wePayUser = wePayUserService.Register(new UserRegisterArguments 
            {
                //Not setting the client id, and secret in here because I set them above.
                Email = Request.Form["email"],
                FirstName = Request.Form["firstName"],
                LastName = Request.Form["lastName"],
                Scope = "", //This will ask for all permissions.
                OriginalIp = Request.UserHostAddress,
                OriginalDevice = Request.UserAgent,
                TOSAcceptanceTime = DateTime.Now,
                RedirectUri = Request.Form["redirectUri"],
                CallbackUri = Request.Form["callbackUri"]
            });

            return View("Get", wePayUser);
        }

        public ActionResult SendConfirmation()
        {
            var wePayUserService = new WePay.WePayUserService(Request.Form["accessToken"]);
            var wePayUser = wePayUserService.SendConfirmation(new UserSendConfirmationArguments { EmailMessage = Request.Form["emailMessage"] });

            return View("Get", wePayUser);
        }
    }
}