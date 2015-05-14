using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_plan#create
    /// </summary>
    public class WePaySubscriptionPlanModifyeArguments
    {
        [JsonProperty("subscription_plan_id", Required = Required.Always)]
        public long SubscriptionPlanId { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("short_description", Required = Required.Always)]
        public string ShortDescription { get; set; }

        [JsonProperty("amount", Required = Required.Always)]
        public decimal Amount { get; set; }

        [JsonProperty("app_fee")]
        public decimal AppFee { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        [JsonProperty("trial_length")]
        public long TrialLength { get; set; }

        [JsonProperty("setup_fee")]
        public decimal SetupFee { get; set; }

        [JsonProperty("update_subscriptions")]
        public string UpdateSubscriptions { get; set; }

        [JsonProperty("transition_expire_days")]
        public long TransitionExpireDays { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        public string BatchUrl() { return "/subscription_plan/modify"; }
    }
}
