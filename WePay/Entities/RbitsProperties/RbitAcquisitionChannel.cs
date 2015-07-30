using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#acquisition_channel
    /// </summary>
    public class RbitAcquisitionChannel : WepayRbitBase
    {
        [JsonProperty("acquisition_channel_type", Required = Required.Always)]
        public string AcquisitionChannelType { get; set; }

        [JsonProperty("referring_uri")]
        public string ReferringUri { get; set; }

        [JsonProperty("affiliate_name")]
        public string AffiliateName { get; set; }
    }
}
