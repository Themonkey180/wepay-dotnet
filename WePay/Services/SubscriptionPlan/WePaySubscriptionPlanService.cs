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
        public WePaySubscriptionPlanService(string accessToken = null, long? accountId = null) : base(accessToken, accountId) { }

        public virtual WePaySubscriptionPlan Get(SubscriptionPlanArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlan, AccessToken, parameters);

            return WepayMapping<WePaySubscriptionPlan>.MapFromJson(response);
        }

        public virtual WePaySubscriptionPlan[] Find(SubscriptionPlanFindArguments arguments)
        {
            arguments.AccountId = arguments.AccountId.Equals(null) ? (AccountId == null ? WePayConfiguration.GetAccountId() : AccountId) : arguments.AccountId;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlanFind, AccessToken, parameters);

            return WepayMapping<WePaySubscriptionPlan[]>.MapFromJson(response);
        }

        public virtual WePaySubscriptionPlan Create(SubscriptionPlanCreateArguments arguments)
        {
            arguments.AccountId = arguments.AccountId.Equals(null) ? (AccountId == null ? WePayConfiguration.GetAccountId() : AccountId) : arguments.AccountId;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlanCreate, AccessToken, parameters);

            return WepayMapping<WePaySubscriptionPlan>.MapFromJson(response);
        }

        public virtual WePaySubscriptionPlan Modify(SubscriptionPlanModifyeArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlanModify, AccessToken, parameters);

            return WepayMapping<WePaySubscriptionPlan>.MapFromJson(response);
        }

        public virtual WePaySubscriptionPlanState Delete(SubscriptionPlanDeleteArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.SubscriptionPlanDelete, AccessToken, parameters);

            return WepayMapping<WePaySubscriptionPlanState>.MapFromJson(response);
        }

    }
}
