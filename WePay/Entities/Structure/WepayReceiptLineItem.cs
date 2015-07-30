using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayReceiptLineItem
    {
        [JsonProperty("description", Required = Required.Always)]
        public string Description { get; set; }

        [JsonProperty("item_price", Required = Required.Always)]
        public decimal ItemPrice { get; set; }

        [JsonProperty("quantity", Required = Required.Always)]
        public decimal Quantity { get; set; }

        [JsonProperty("amount", Required = Required.Always)]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("project_name")]
        public string ProjectName { get; set; }

        [JsonProperty("service_billing_method")]
        public string ServiceBillingMethod { get; set; }
    }
}
