using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription#create
    /// </summary>
    public class WePaySubscriptionCreateArguments
    {
        [JsonProperty("subscription_plan_id", Required = Required.Always)]
        public long SubscriptionPlanId { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        [JsonProperty("payment_method_id")]
        public long PaymentMethodId { get; set; }

        [JsonProperty("payment_method_type")]
        public string PaymentMethodType { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("prefill_info")]
        public WepayPrefillInfo PrefillInfo { get; set; }

        public string BatchUrl() { return "/subscription/create"; }
    }
}
