using System.Web.Mvc;
using WePay;
using WePay.Infrastructure;
using WePay.Entities;
using WePay.User;

namespace Controllers
{
    [RouteArea("User", AreaPrefix = "user")]
    [Route("{action=index}")]
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get()
        {
            var accessToken = Request.Form["accessToken"];
            WePay.WePayConfiguration.SetAccessToken(accessToken);
            var wePayUserService = new WePay.WePayUserService(accessToken);
            var wePayUser = wePayUserService.Get();

            return View(wePayUser);
        }

        public ActionResult Modify()
        {
            var accessToken = Request.Form["accessToken"];
            var callbackUri = Request.Form["callbackUri"];

            WePay.WePayConfiguration.SetAccessToken(accessToken);

            var wePayUserService = new WePay.WePayUserService(accessToken);
            var wePayUser = wePayUserService.Modify(new UserModifyArguments { CallbackUri = callbackUri });

            return View(wePayUser);
        }
        
    }
}