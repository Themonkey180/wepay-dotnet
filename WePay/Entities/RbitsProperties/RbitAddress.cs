using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#address
    /// </summary>
    public class RbitAddress : WepayRbitBase
    {
        [JsonProperty("address", Required = Required.Always)]
        public WepayShippingAddress Address { get; set; }

        [JsonProperty("address_type")]
        public string AddressType { get; set; }

        [JsonProperty("normalized_address", Required = Required.Always)]
        public WepayShippingAddress NormalizedAddress { get; set; }

        [JsonProperty("normalized_source")]
        public string NormalizedSource { get; set; }

        [JsonProperty("normalized_address_status")]
        public string NormalizedAddressStatus { get; set; }
    }
}
