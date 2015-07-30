using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#transaction_details
    /// </summary>
    public class RbitTransactionDetails : WepayRbitBase
    {
        [JsonProperty("receipt_uri")]
        public string ReceiptUri { get; set; }

        [JsonProperty("itemized_receipt")]
        public WepayReceiptLineItem[] ItemizedReceipt { get; set; }

        [JsonProperty("terms_uri")]
        public string TermsUri { get; set; }

        [JsonProperty("shipping_address")]
        public WepayShippingAddress ShippingAddress { get; set; }

        [JsonProperty("shipping_info")]
        public WepayShipping[] ShippingInfo { get; set; }
    }
}
