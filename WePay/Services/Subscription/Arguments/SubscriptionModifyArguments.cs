using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay.Subscription
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription#modify
    /// </summary>
    public class SubscriptionModifyArguments
    {
        [JsonProperty("subscription_id", Required = Required.Always)]
        public long SubscriptionId { get; set; }

        [JsonProperty("subscription_plan_id")]
        public long SubscriptionPlanId { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("prorate")]
        public bool? Prorate { get; set; }

        [JsonProperty("transition_expire_days")]
        public long TransitionExpireDays { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        [JsonProperty("payment_method_id")]
        public long PaymentMethodId { get; set; }

        [JsonProperty("payment_method_type")]
        public string PaymentMethodType { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("extend_trial_days")]
        public long ExtendTrialDays { get; set; }

        public string BatchUrl() { return "/subscription/modify"; }
    }
}
