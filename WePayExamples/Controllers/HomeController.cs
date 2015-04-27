using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Text;
using System.Configuration;
using WePay;

namespace Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUser()
        {
            var accessToken = Request.Form["accessToken"];
            WePay.WePayConfiguration.SetAccessToken(accessToken);
            var wePayUserService = new WePay.WePayUserService(accessToken);
            var wePayUser = wePayUserService.Get();

            return View(wePayUser);
        }

        public ActionResult GetAccount()
        {
            long AccountId = 0;
            var accessToken = Request.Form["accessToken"];
            long.TryParse(Request.Form["AccountId"], out AccountId);
            WePay.WePayConfiguration.SetAccessToken(accessToken);
            var wePayAccountService = new WePay.WePayAccountrService(accessToken);
            var wePayAccount = wePayAccountService.Get(new WePayAccountArguments { AccountId = AccountId });

            return View(wePayAccount);
        }

        public ActionResult FindAccount()
        {
            var name = Request.Form["name"];
            var referenceId = Request.Form["referenceId"];
            var sortOrder = Request.Form["sortOrder"];
            var accessToken = Request.Form["accessToken"];

            var wePayAccountService = new WePay.WePayAccountrService(accessToken);
            var wePayAccount = wePayAccountService.Find(new WePayFindAccountArguments { Name = name, ReferenceId = referenceId, SortOrder = sortOrder });

            return View(wePayAccount);
        }
    }
}