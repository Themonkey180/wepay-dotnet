using Newtonsoft.Json;
using System;
using WePay.Infrastructure;

namespace WePay.User
{
    public class UserSendConfirmationArguments
    {
        [JsonProperty("email_message")]
        public string EmailMessage { get; set; }

        public string BatchUrl() { return "/user/send_confirmation"; }
    }
}
