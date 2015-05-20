using WePay.Entities;
using WePay.Infrastructure;
using WePay.Services;
using WePay.SubscriptionCharge;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_charge
    /// </summary>
    public class WePaySubscriptionChargeService : WepayService
    {
        public WePaySubscriptionChargeService(string accessToken = null) : base(accessToken) { }

        public virtual WePaySubscriptionCharge Get(SubscriptionChargeArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionCharge, AccessToken, parameters);

            return Mapper<WePaySubscriptionCharge>.MapFromJson(response);
        }

        public virtual WePaySubscriptionCharge[] Find(SubscriptionChargeFindArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionChargeFind, AccessToken, parameters);

            return Mapper<WePaySubscriptionCharge[]>.MapFromJson(response);
        }

        public virtual WePaySubscriptionChargeState Refund(SubscriptionChargeRefundArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionChargeRefund, AccessToken, parameters);

            return Mapper<WePaySubscriptionChargeState>.MapFromJson(response);
        }
    }
}
