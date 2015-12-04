using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayBankDataResponse
    {
        [JsonProperty("bank_name")]
        public string BankName { get; set; }

        [JsonProperty("account_last_four")]
        public string AccountLastFour { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }
    }
}
