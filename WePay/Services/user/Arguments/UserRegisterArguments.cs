using Newtonsoft.Json;
using System;
using WePay.Infrastructure;

namespace WePay.User
{
    public class UserRegisterArguments
    {
        [JsonProperty("client_id", Required = Required.Always)]
        public long? ClientId { get; set; }

        [JsonProperty("client_secret", Required = Required.Always)]
        public string ClientSecret { get; set; }

        [JsonProperty("email", Required = Required.Always)]
        public string Email { get; set; }

        [JsonProperty("scope", Required = Required.Always)]
        public string Scope { get; set; }

        [JsonProperty("first_name", Required = Required.Always)]
        public string FirstName { get; set; }

        [JsonProperty("last_name", Required = Required.Always)]
        public string LastName { get; set; }

        [JsonProperty("original_ip", Required = Required.Always)]
        public string OriginalIp { get; set; }

        [JsonProperty("original_device", Required = Required.Always)]
        public string OriginalDevice { get; set; }

        [JsonProperty("tos_acceptance_time", Required = Required.Always)]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? TOSAcceptanceTime { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        public string BatchUrl() { return "/user/register"; }
    }
}
