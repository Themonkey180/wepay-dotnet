using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayCountryOptions
    {
        [JsonProperty("debit_opt_in")]
        public bool? DebitOptIn { get; set; }
    }
}
