using Newtonsoft.Json;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#device_info
    /// </summary>
    public class RbitDeviceInfo : WepayRbitBase
    {
        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }

        [JsonProperty("IMEI")]
        public string IMEI { get; set; }

        [JsonProperty("true_ip")]
        public string TrueIp { get; set; }

        [JsonProperty("third_party_device_id")]
        public string ThirdPartyDeviceId { get; set; }

        [JsonProperty("third_party_device_type")]
        public string ThirdPartyDeviceType { get; set; }
    }
}
