using Newtonsoft.Json;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/checkout#cancel
    /// </summary>
    public class WePayCheckoutRefundArguments
    {
        [JsonProperty("checkout_id", Required = Required.Always)]
        public long CheckoutId { get; set; }

        [JsonProperty("refund_reason", Required = Required.Always)]
        public string RefundReason { get; set; }

        [JsonProperty("amount")]
        public decimal RefundReason { get; set; }

        [JsonProperty("app_fee")]
        public decimal AppFee { get; set; }

        [JsonProperty("payer_email_message")]
        public string PayerEmailMessage { get; set; }

        [JsonProperty("payee_email_message")]
        public string PayeeEmailMessage { get; set; }
    }
}
