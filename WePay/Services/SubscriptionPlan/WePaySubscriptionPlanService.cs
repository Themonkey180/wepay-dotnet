using WePay.Entities;
using WePay.Infrastructure;
using WePay.Services;
using WePay.SubscriptionPlan;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_plan
    /// </summary>
    public class WePaySubscriptionPlanService : WepayService
    {
        public WePaySubscriptionPlanService(string accessToken = null) : base(accessToken) { }

        public virtual WePaySubscriptionPlan Get(SubscriptionPlanArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlan, AccessToken, parameters);

            return Mapper<WePaySubscriptionPlan>.MapFromJson(response);
        }

        public virtual WePaySubscriptionPlan[] Find(SubscriptionPlanFindArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlanFind, AccessToken, parameters);

            return Mapper<WePaySubscriptionPlan[]>.MapFromJson(response);
        }

        public virtual WePaySubscriptionPlan Create(SubscriptionPlanCreateArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlanCreate, AccessToken, parameters);

            return Mapper<WePaySubscriptionPlan>.MapFromJson(response);
        }

        public virtual WePaySubscriptionPlan Modify(SubscriptionPlanModifyeArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlanModify, AccessToken, parameters);

            return Mapper<WePaySubscriptionPlan>.MapFromJson(response);
        }

        public virtual WePaySubscriptionPlanState Delete(SubscriptionPlanDeleteArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlanDelete, AccessToken, parameters);

            return Mapper<WePaySubscriptionPlanState>.MapFromJson(response);
        }

    }
}
