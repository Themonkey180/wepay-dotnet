using Newtonsoft.Json;
using System;
using WePay.Infrastructure;

namespace WePay
{
    public class WePayUserSendConfirmationArguments
    {
        [JsonProperty("email_message")]
        public string EmailMessage { get; set; }
    }
}
