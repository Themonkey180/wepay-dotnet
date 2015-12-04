using System.Web.Mvc;
using WePay;
using WePay.App;

namespace Controllers
{
    [RouteArea("App", AreaPrefix = "app")]
    [Route("{action=index}")]
    public class AppController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get()
        {
            long clientId = 0;
            var accessToken = Request.Form["accessToken"];
            var clientSecret = Request.Form["ClientSecret"];
            long.TryParse(Request.Form["clientId"], out clientId);

            WePay.WePayConfiguration.SetAccessToken(accessToken);
            var WePayAppService = new WePay.WePayAppService(accessToken, clientId, clientSecret);
            var wePayApp = WePayAppService.Get(new AppArguments { });

            return View(wePayApp);
        }
    }
}