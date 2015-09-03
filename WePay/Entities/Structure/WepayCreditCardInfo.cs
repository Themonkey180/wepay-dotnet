using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayCreditCardInfo
    {
        [JsonProperty("id")]
        public long? Id { get; set; }
    }
}
