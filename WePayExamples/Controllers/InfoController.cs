using System.Web.Mvc;
using WePay;

namespace Controllers
{
    [RouteArea("Info")]
    public class InfoController : Controller
    {
        [Route("set")]
        public ActionResult Set()
        {
            dynamic data = new System.Dynamic.ExpandoObject();

            var accessToken = Request.Form["accessToken"];
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                data.accessToken = accessToken;
                WePayConfiguration.SetAccessToken(accessToken);
            }

            var clientSecret = Request.Form["clientSecret"];
            if (!string.IsNullOrWhiteSpace(clientSecret))
            {
                data.clientSecret = clientSecret;
                WePayConfiguration.SetClientSecret(clientSecret);
            }

            long accountId;
            var accountIdIn = Request.Form["accountId"];
            if (long.TryParse(accountIdIn, out accountId))
            {
                data.accountId = accountId;
                WePayConfiguration.SetAccountId(accountId);
            }

            long clientId;
            var clientIdIn = Request.Form["clientId"];
            if (long.TryParse(clientIdIn, out clientId))
            {
                data.clientId = clientId;
                WePayConfiguration.SetClientId(clientId);
            }

            return Json(data);
        }
    }
}

