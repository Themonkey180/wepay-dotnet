using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public WePayCheckoutService(string accessToken = null) : base(accessToken) { }

        public virtual WePayCheckout Get(WePayCheckoutArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.Checkout, AccessToken, parameters);

            return Mapper<WePayCheckout>.MapFromJson(response);
        }

        public virtual WePayCheckout[] Find(WePayCheckoutFindArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CheckoutFind, AccessToken, parameters);

            return Mapper<WePayCheckout[]>.MapFromJson(response);
        }

        public virtual WePayCheckout Create(WePayCheckoutCreateArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CheckoutCreate, AccessToken, parameters);

            return Mapper<WePayCheckout>.MapFromJson(response);
        }

        public virtual WePayCheckoutState Cancel(WePayCheckoutCancelArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CheckoutCancel, AccessToken, parameters);

            return Mapper<WePayCheckoutState>.MapFromJson(response);
        }

        public virtual WePayCheckoutState Refund(WePayCheckoutCancelArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CheckoutRefund, AccessToken, parameters);

            return Mapper<WePayCheckoutState>.MapFromJson(response);
        }

        public virtual WePayCheckoutState Capture(WePayCheckoutCancelArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CheckoutCapture, AccessToken, parameters);

            return Mapper<WePayCheckoutState>.MapFromJson(response);
        }

        public virtual WePayCheckout Modify(WePayCheckoutCreateArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CheckoutModify, AccessToken, parameters);

            return Mapper<WePayCheckout>.MapFromJson(response);
        }
    }
}
