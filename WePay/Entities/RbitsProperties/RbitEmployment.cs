using Newtonsoft.Json;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#employment
    /// </summary>
    public class RbitEmployment : WepayRbitBase
    {
        [JsonProperty("timing")]
        public string timing { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }
    }
}
