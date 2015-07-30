using Newtonsoft.Json;
using System;
using WePay.Infrastructure;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#external_account
    /// </summary>
    public class RbitExternalAccount : WepayRbitBase
    {
        [JsonProperty("is_partner_account", Required = Required.Always)]
        public string IsPartnerAccount { get; set; }

        [JsonProperty("account_type", Required = Required.Always)]
        public string AccountType { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("create_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? CreateTime { get; set; }

        [JsonProperty("modify_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? ModifyTime { get; set; }

        [JsonProperty("following")]
        public int Following { get; set; }

        [JsonProperty("followers")]
        public int Followers { get; set; }

        [JsonProperty("connections")]
        public int Connections { get; set; }

        [JsonProperty("feedback_scores_provided")]
        public int FeedbackScoresProvided { get; set; }

        [JsonProperty("feedback_score_percent_positive")]
        public float FeedbackScorePercentPositive { get; set; }

        [JsonProperty("feedback_average_score")]
        public float FeedbackAverageScore { get; set; }

    }
}
