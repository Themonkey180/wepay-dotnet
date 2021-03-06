﻿using Newtonsoft.Json;
using System;
using WePay.Entities;
using WePay.Entities.Rbits;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Account
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit#create
    /// </summary>
    public class RbitCreateArgument
    {

        [JsonProperty("associated_object_type", Required = Required.Always)]
        public string AssociatedObjectType { get; set; }

        [JsonProperty("associated_object_id", Required = Required.Always)]
        public long? AssociatedObjectId { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty("properties", Required = Required.Always)]
        public WepayRbitBase Properties { get; set; }

        [JsonProperty("receive_time", Required = Required.Always)]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? ReceiveTime { get; set; }

        [JsonProperty("source", Required = Required.Always)]
        public string Source { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("related_rbits")]
        [JsonConverter(typeof(WePayRbitsConverter))]
        public WepayRbitStructure[] RelatedRbits { get; set; }

        public string BatchUrl() { return "/rbit/create"; }
    }
}
