using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayMFASetupData
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
