using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayPreapprovalInfo
    {
        [JsonProperty("id")]
        public long? Id { get; set; }
    }
}
