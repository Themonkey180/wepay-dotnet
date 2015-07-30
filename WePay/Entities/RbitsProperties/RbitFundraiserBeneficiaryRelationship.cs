using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#fundraiser_beneficiary_relationship
    /// </summary>
    public class RbitFundraiserBeneficiaryRelationship : WepayRbitBase
    {
        [JsonProperty("fundraiser_beneficiary_relationship", Required = Required.Always)]
        public string FundraiserBeneficiaryRelationship { get; set; }

        [JsonProperty("additional_relationship_info")]
        public string AdditionalRelationshipInfo { get; set; }
    }
}
