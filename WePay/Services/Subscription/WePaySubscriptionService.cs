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
    /// https://www.wepay.com/developer/reference/subscription
    /// </summary>
    public class WePaySubscriptionService : WepayService
    {
        public WePaySubscriptionService(string accessToken = null) : base(accessToken) { }

        public virtual WePaySubscription Get(WePaySubscriptionArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlan, AccessToken, parameters);

            return Mapper<WePaySubscription>.MapFromJson(response);
        }

        public virtual WePaySubscription[] Find(WePaySubscriptionFindArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlanFind, AccessToken, parameters);

            return Mapper<WePaySubscription[]>.MapFromJson(response);
        }

        public virtual WePaySubscriptionCreate Create(WePaySubscriptionCreateArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlanCreate, AccessToken, parameters);

            return Mapper<WePaySubscriptionCreate>.MapFromJson(response);
        }

        public virtual WePaySubscription Modify(WePaySubscriptionModifyeArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlanModify, AccessToken, parameters);

            return Mapper<WePaySubscription>.MapFromJson(response);
        }

        public virtual WePaySubscriptionState Cancel(WePaySubscriptionCancelArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlanDelete, AccessToken, parameters);

            return Mapper<WePaySubscriptionState>.MapFromJson(response);
        }

    }
}
