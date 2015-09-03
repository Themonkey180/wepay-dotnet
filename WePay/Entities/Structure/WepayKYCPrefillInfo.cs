using Newtonsoft.Json;
using System;
using WePay.Infrastructure;

namespace WePay.Entities.Structure
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/structures#kyc_prefill_info
    /// </summary>
    public class WepayKYCPrefillInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("dob")]
        [JsonConverter(typeof(WePayBirthDateConverter))]
        public DateTime? Dob { get; set; }

        [JsonProperty("entity_name")]
        public string EntityName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

    }
}
