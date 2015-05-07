using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_plan#create
    /// </summary>
    public class WePaySubscriptionPlanCreateArguments
    {
        [JsonProperty("account_id", Required = Required.Always)]
        public long AccountId { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("short_description", Required = Required.Always)]
        public string ShortDescription { get; set; }

        [JsonProperty("amount", Required = Required.Always)]
        public decimal Amount { get; set; }

        [JsonProperty("period", Required = Required.Always)]
        public string Period { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("app_fee")]
        public decimal AppFee { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        [JsonProperty("trial_length")]
        public long TrialLength { get; set; }

        [JsonProperty("SetupFee")]
        public decimal SetupFee { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        public string BatchUrl() { return "/subscription_plan/create"; }
    }
}
