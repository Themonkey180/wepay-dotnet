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
    /// https://www.wepay.com/developer/reference/subscription_plan
    /// </summary>
    public class WePaySubscriptionPlanService : WepayService
    {
        public WePaySubscriptionPlanService(string accessToken = null) : base(accessToken) { }

        public virtual WePaySubscriptionPlan Get(WePaySubscriptionPlanArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlan, AccessToken, parameters);

            return Mapper<WePaySubscriptionPlan>.MapFromJson(response);
        }

        public virtual WePaySubscriptionPlan[] Find(WePaySubscriptionPlanFindArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlanFind, AccessToken, parameters);

            return Mapper<WePaySubscriptionPlan[]>.MapFromJson(response);
        }

        public virtual WePaySubscriptionPlan Create(WePaySubscriptionPlanCreateArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlanCreate, AccessToken, parameters);

            return Mapper<WePaySubscriptionPlan>.MapFromJson(response);
        }

        public virtual WePaySubscriptionPlan Modify(WePaySubscriptionPlanModifyeArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlanModify, AccessToken, parameters);

            return Mapper<WePaySubscriptionPlan>.MapFromJson(response);
        }

        public virtual WePaySubscriptionPlanState Delete(WePaySubscriptionPlanDeleteArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlanDelete, AccessToken, parameters);

            return Mapper<WePaySubscriptionPlanState>.MapFromJson(response);
        }

    }
}
