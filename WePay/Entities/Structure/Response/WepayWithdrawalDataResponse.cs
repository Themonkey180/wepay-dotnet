using Newtonsoft.Json;
using System;
using WePay.Infrastructure;

namespace WePay.Entities.Structure
{
    public class WepayWithdrawalDataResponse
    {
        [JsonProperty("create_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? CreateTime { get; set; }

        [JsonProperty("capture_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? CaptureTime { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectURI { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackURI { get; set; }

        [JsonProperty("withdrawal_uri")]
        public string WithdrawalURI { get; set; }
    }
}
