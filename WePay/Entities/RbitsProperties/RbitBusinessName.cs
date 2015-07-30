using Newtonsoft.Json;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#business-name
    /// </summary>
    public class RbitBusinessName : WepayRbitBase
    {
        [JsonProperty("business_name", Required = Required.Always)]
        public string BusinessName { get; set; }

        [JsonProperty("name_type")]
        public string NameType { get; set; }
    }
}
