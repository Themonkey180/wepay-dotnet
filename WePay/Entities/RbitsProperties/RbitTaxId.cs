using Newtonsoft.Json;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#tax_id
    /// </summary>
    public class RbitTaxId : WepayRbitBase
    {
        [JsonProperty("tax_id", Required = Required.Always)]
        public string TaxId { get; set; }

        [JsonProperty("tax_id_country", Required = Required.Always)]
        public string TaxIdCountry { get; set; }

        [JsonProperty("tax_id_type", Required = Required.Always)]
        public string TaxIdType { get; set; }
    }
}
