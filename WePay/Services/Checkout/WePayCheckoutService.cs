using WePay.Checkout;
using WePay.Entities;
using WePay.Infrastructure;
using WePay.Services;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/checkout
    /// </summary>
    public class WePayCheckoutService : WepayService
    {
        public WePayCheckoutService(string accessToken = null, long? accountId = null) : base(accessToken, accountId) { }

        public virtual WePayCheckout Get(CheckoutArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.Checkout, AccessToken, parameters);

            return WepayMapping<WePayCheckout>.MapFromJson(response);
        }

        public virtual WePayCheckout[] Find(CheckoutFindArguments arguments)
        {
            arguments.AccountId = arguments.AccountId.Equals(null) ? (AccountId == null ? WePayConfiguration.GetAccountId() : AccountId) : arguments.AccountId;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CheckoutFind, AccessToken, parameters);

            return WepayMapping<WePayCheckout[]>.MapFromJson(response);
        }

        public virtual WePayCheckout Create(CheckoutCreateArguments arguments)
        {
            arguments.AccountId = arguments.AccountId.Equals(null) ? (AccountId == null ? WePayConfiguration.GetAccountId() : AccountId) : arguments.AccountId;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CheckoutCreate, AccessToken, parameters);

            return WepayMapping<WePayCheckout>.MapFromJson(response);
        }

        public virtual WePayCheckoutState Cancel(CheckoutCancelArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CheckoutCancel, AccessToken, parameters);

            return WepayMapping<WePayCheckoutState>.MapFromJson(response);
        }

        public virtual WePayCheckoutState Refund(CheckoutRefundArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CheckoutRefund, AccessToken, parameters);

            return WepayMapping<WePayCheckoutState>.MapFromJson(response);
        }

        public virtual WePayCheckoutState Capture(CheckoutCancelArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CheckoutCapture, AccessToken, parameters);

            return WepayMapping<WePayCheckoutState>.MapFromJson(response);
        }

        public virtual WePayCheckout Modify(CheckoutCreateArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CheckoutModify, AccessToken, parameters);

            return WepayMapping<WePayCheckout>.MapFromJson(response);
        }
    }
}
