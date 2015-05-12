using Newtonsoft.Json;

namespace WePay.Entities
{
    public class WePayUserSendConfirmation : WepayBatch
    {
        [JsonProperty("user_id")]
        public long UserID { get; set; }

        [JsonProperty("user_name")]
        public string FullName { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
