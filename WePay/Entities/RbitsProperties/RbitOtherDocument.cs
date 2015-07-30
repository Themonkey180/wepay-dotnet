using Newtonsoft.Json;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#other_document
    /// </summary>
    public class RbitOtherDocument : WepayRbitBase
    {
        [JsonProperty("uri", Required = Required.Always)]
        public string Uri { get; set; }

    }
}
