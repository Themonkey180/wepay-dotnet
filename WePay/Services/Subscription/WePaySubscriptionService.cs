using WePay.Entities;
using WePay.Infrastructure;
using WePay.Services;
using WePay.Subscription;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription
    /// </summary>
    public class WePaySubscriptionService : WepayService
    {
        public WePaySubscriptionService(string accessToken = null) : base(accessToken) { }

        public virtual WePaySubscription Get(SubscriptionArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.Subscription, AccessToken, parameters);

            return WepayMapping<WePaySubscription>.MapFromJson(response);
        }

        public virtual WePaySubscription[] Find(SubscriptionFindArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionFind, AccessToken, parameters);

            return WepayMapping<WePaySubscription[]>.MapFromJson(response);
        }

        public virtual WePaySubscriptionCreate Create(SubscriptionCreateArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionCreate, AccessToken, parameters);

            return WepayMapping<WePaySubscriptionCreate>.MapFromJson(response);
        }

        public virtual WePaySubscription Modify(SubscriptionModifyArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionModify, AccessToken, parameters);

            return WepayMapping<WePaySubscription>.MapFromJson(response);
        }

        public virtual WePaySubscriptionState Cancel(SubscriptionCancelArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionCancel, AccessToken, parameters);

            return WepayMapping<WePaySubscriptionState>.MapFromJson(response);
        }

    }
}
