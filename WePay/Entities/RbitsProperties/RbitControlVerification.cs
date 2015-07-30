using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#control_verification
    /// </summary>
    public class RbitControlVerification : WepayRbitBase
    {
        [JsonProperty("verification_type", Required = Required.Always)]
        public string CerificationType { get; set; }

        [JsonProperty("verified_email")]
        public string VerifiedEmail { get; set; }

        [JsonProperty("verified_phone")]
        public string VerifiedPhone { get; set; }
    }
}
