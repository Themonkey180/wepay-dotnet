using Newtonsoft.Json;

namespace WePay.SubscriptionPlan
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_plan#find
    /// </summary>
    public class SubscriptionPlanFindArguments
    {
        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("start")]
        public long start { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        public string BatchUrl() { return "/subscription_plan/find"; }
    }
}
