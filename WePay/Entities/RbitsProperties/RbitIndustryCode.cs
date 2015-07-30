using Newtonsoft.Json;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#industry_code
    /// </summary>
    public class RbitIndustryCode : WepayRbitBase
    {
        [JsonProperty("industry_code_type", Required = Required.Always)]
        public string IndustryCodeType { get; set; }

        [JsonProperty("industry_code", Required = Required.Always)]
        public string IndustryCode { get; set; }

        [JsonProperty("industry_detail")]
        public string IndustryDetail { get; set; }
    }
}
