using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription#lookup
    /// </summary>
    public class WePaySubscription
    {
        [JsonProperty("subscription_plan_id")]
        public long SubscriptionPlanId { get; set; }

        [JsonProperty("subscription_id")]
        public long SubscriptionId { get; set; }

        [JsonProperty("subscription_uri")]
        public string SubscriptionUri { get; set; }

        [JsonProperty("payer_name")]
        public string PayerName { get; set; }

        [JsonProperty("payer_email")]
        public string PayerEmail { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("app_fee")]
        public decimal AppFee { get; set; }

        [JsonProperty("fee_payer")]
        public string FeePayer { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("create_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? CreateTime { get; set; }

        [JsonProperty("redirect_uri")]
        public long RedirectUri { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        [JsonProperty("payment_method_id")]
        public long PaymentMethodId { get; set; }

        [JsonProperty("payment_method_type")]
        public string PaymentMethodType { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("trial_days_remaining")]
        public long TrialDaysRemaining { get; set; }

        [JsonProperty("transition_expire_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? TransitionExpireTime { get; set; }

        [JsonProperty("transition_prorate")]
        public bool TransitionProrate { get; set; }

        [JsonProperty("transition_quantity")]
        public long TransitionQuantity { get; set; }

        [JsonProperty("transition_subscription_plan_id")]
        public long TransitionSubscriptionPlanId { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }
    }
}
