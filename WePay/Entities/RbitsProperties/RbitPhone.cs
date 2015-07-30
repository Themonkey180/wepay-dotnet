using Newtonsoft.Json;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#phone
    /// </summary>
    public class RbitPhone : WepayRbitBase
    {
        [JsonProperty("phone", Required = Required.Always)]
        public string Phone { get; set; }

        [JsonProperty("phone_type")]
        public string PhoneType { get; set; }
    }
}
