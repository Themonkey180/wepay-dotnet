using Newtonsoft.Json;
using System;
using WePay.Infrastructure;

namespace WePay.Entities.Structure
{
    public class WepayShipping
    {
        [JsonProperty("expected_delivery_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? expected_delivery_time { get; set; }

        [JsonProperty("shipping_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? shipping_time { get; set; }

        [JsonProperty("carrier")]
        public string carrier { get; set; }

        [JsonProperty("tracking_number")]
        public string tracking_number { get; set; }

        [JsonProperty("tracking_url")]
        public string tracking_url { get; set; }

        [JsonProperty("actual_delivery_time")]
        public string actual_delivery_time { get; set; }

    }
}
