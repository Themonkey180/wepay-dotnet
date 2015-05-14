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
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_charge
    /// </summary>
    public class WePaySubscriptionChargeService : WepayService
    {
        public WePaySubscriptionChargeService(string accessToken = null) : base(accessToken) { }

        public virtual WePaySubscriptionCharge Get(WePaySubscriptionChargeArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionCharge, AccessToken, parameters);

            return Mapper<WePaySubscriptionCharge>.MapFromJson(response);
        }

        public virtual WePaySubscriptionCharge[] Find(WePaySubscriptionChargeFindArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionChargeFind, AccessToken, parameters);

            return Mapper<WePaySubscriptionCharge[]>.MapFromJson(response);
        }

        public virtual WePaySubscriptionChargeState Refund(WePaySubscriptionChargeRefundArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionChargeRefund, AccessToken, parameters);

            return Mapper<WePaySubscriptionChargeState>.MapFromJson(response);
        }
    }
}
