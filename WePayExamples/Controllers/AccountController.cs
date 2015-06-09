using System.Web.Mvc;
using WePay;
using WePay.Infrastructure;
using WePay.Entities;
using WePay.Account;

namespace Controllers
{
    [RouteArea("Account", AreaPrefix = "account")]
    [Route("{action=index}")]
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get()
        {
            long AccountId = 0;
            var accessToken = Request.Form["accessToken"];
            long.TryParse(Request.Form["AccountId"], out AccountId);
            WePay.WePayConfiguration.SetAccessToken(accessToken);
            var wePayAccountService = new WePay.WePayAccountrService(accessToken);
            var wePayAccount = wePayAccountService.Get(new AccountArguments { AccountId = AccountId });

            return View(wePayAccount);
        }

        public ActionResult Find()
        {
            var name = Request.Form["name"];
            var referenceId = Request.Form["referenceId"];
            var sortOrder = Request.Form["sortOrder"];
            var accessToken = Request.Form["accessToken"];

            var wePayAccountService = new WePay.WePayAccountrService(accessToken);
            var wePayAccount = wePayAccountService.Find(new AccountFindArguments { Name = name, ReferenceId = referenceId, SortOrder = sortOrder });

            return View(wePayAccount);
        }
    }
}