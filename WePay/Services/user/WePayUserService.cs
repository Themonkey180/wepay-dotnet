using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WePay.Entities;
using WePay.Infrastructure;
using WePay.Services;

namespace WePay
{
    public class WePayUserService : WepayService
    {
        public WePayUserService(string accessToken = null) : base(accessToken) { }

        public virtual WePayUser Get()
        {
            var response = Requestor.PostStringBearer(Urls.User, AccessToken);

            return Mapper<WePayUser>.MapFromJson(response);
        }
    }
}
