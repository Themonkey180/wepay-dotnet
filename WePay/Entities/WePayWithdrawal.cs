using Newtonsoft.Json;
using System;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/withdrawal#lookup
    /// </summary>
    public class WePayWithdrawal
    {
        [JsonProperty("withdrawal_id")]
        public long WithdrawalId { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("withdrawal_uri")]
        public string WithdrawalUri { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("recipient_name")]
        public string RecipientName { get; set; }

        [JsonProperty("recipient_confirmed")]
        public bool RecipientConfirmed { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("create_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? CreateTime { get; set; }

        [JsonProperty("capture_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? CaptureTime { get; set; }
    }
}
