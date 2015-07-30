using Newtonsoft.Json;
using System;
using WePay.Infrastructure;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#person
    /// </summary>
    public class RbitPerson : WepayRbitBase
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("birthdate")]
        [JsonConverter(typeof(WePayBirthDateConverter))]
        public DateTime?  Birthdate { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }
}
