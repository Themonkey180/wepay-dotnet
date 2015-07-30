using Newtonsoft.Json;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#email
    /// </summary>
    public class RbitEmail : WepayRbitBase
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }
    }
}
