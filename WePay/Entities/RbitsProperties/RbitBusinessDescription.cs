using Newtonsoft.Json;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#business_description
    /// </summary>
    public class RbitBusinessDescription : WepayRbitBase
    {
        [JsonProperty("business_description", Required = Required.Always)]
        public string BusinessDescription { get; set; }
    }
}
