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
    /// https://www.wepay.com/developer/reference/credit_card
    /// </summary>
    public class WePayCreditCardService : WepayService
    {
        public WePayCreditCardService(string accessToken = null, long? clientId = null, string clientSecret = null) : base(accessToken, clientId, clientSecret) { }

        public virtual WePayCreditCard Get(WePayCreditCardArguments arguments)
        {
            arguments.ClientId = arguments.ClientId.Equals(null) ? (ClientId == null ? WePayConfiguration.GetClientId() : ClientId) : arguments.ClientId;
            arguments.ClientSecret = string.IsNullOrWhiteSpace(arguments.ClientSecret) ? (string.IsNullOrWhiteSpace(ClientSecret) ? WePayConfiguration.GetClientSecret() : ClientSecret) : arguments.ClientSecret;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CreditCard, AccessToken, parameters);

            return Mapper<WePayCreditCard>.MapFromJson(response);
        }

        public virtual WePayCreditCard[] Find(WePayCreditCardFindArguments arguments)
        {

            arguments.ClientId = arguments.ClientId.Equals(null) ? (ClientId == null ? WePayConfiguration.GetClientId() : ClientId) : arguments.ClientId;
            arguments.ClientSecret = string.IsNullOrWhiteSpace(arguments.ClientSecret) ? (string.IsNullOrWhiteSpace(ClientSecret) ? WePayConfiguration.GetClientSecret() : ClientSecret) : arguments.ClientSecret;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CreditCardFind, AccessToken, parameters);

            return Mapper<WePayCreditCard[]>.MapFromJson(response);
        }

        public virtual WePayCreditCardState Create(WePayCreditCardCreateArguments arguments)
        {
            arguments.ClientId = arguments.ClientId.Equals(null) ? (ClientId == null ? WePayConfiguration.GetClientId() : ClientId) : arguments.ClientId;
         
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CreditCardCreate, AccessToken, parameters);

            return Mapper<WePayCreditCardState>.MapFromJson(response);
        }

        public virtual WePayCreditCardState Authorize(WePayCreditCardArguments arguments)
        {
            arguments.ClientId = arguments.ClientId.Equals(null) ? (ClientId == null ? WePayConfiguration.GetClientId() : ClientId) : arguments.ClientId;
            arguments.ClientSecret = string.IsNullOrWhiteSpace(arguments.ClientSecret) ? (string.IsNullOrWhiteSpace(ClientSecret) ? WePayConfiguration.GetClientSecret() : ClientSecret) : arguments.ClientSecret;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CreditCardAuthorize, AccessToken, parameters);

            return Mapper<WePayCreditCardState>.MapFromJson(response);
        }

        public virtual WePayCreditCardState Delete(WePayCreditCardArguments arguments)
        {

            arguments.ClientId = arguments.ClientId.Equals(null) ? (ClientId == null ? WePayConfiguration.GetClientId() : ClientId) : arguments.ClientId;
            arguments.ClientSecret = string.IsNullOrWhiteSpace(arguments.ClientSecret) ? (string.IsNullOrWhiteSpace(ClientSecret) ? WePayConfiguration.GetClientSecret() : ClientSecret) : arguments.ClientSecret;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CreditCardDelete, AccessToken, parameters);

            return Mapper<WePayCreditCardState>.MapFromJson(response);
        }

    }
}
