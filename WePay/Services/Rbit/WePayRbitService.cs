using WePay.Account;
using WePay.Entities;
using WePay.Infrastructure;
using WePay.Services;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/account-membership
    /// </summary>
    public class WePayRbitService : WepayService
    {
        public WePayRbitService(string accessToken = null) : base(accessToken) { }

        public virtual WepayRbit Get(RbitGetArgument arguments)
        {

            var url = Urls.RbitGet;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayRbit>.MapRbitsFromJson(response);
        }

        public virtual WepayRbit Create(RbitCreateArgument arguments)
        {

            var url = Urls.RbitCreate;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);
            return Mapper<WepayRbit>.MapRbitsFromJson(response);
        }

        public virtual WepayRbit Find(RbitFindArgument arguments)
        {

            var url = Urls.RbitFind;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayRbit>.MapRbitsFromJson(response);
        }

        public virtual WepayRbit Delete(RbitDeleteArgument arguments)
        {

            var url = Urls.RbitDelete;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayRbit>.MapRbitsFromJson(response);
        }
    }
}
