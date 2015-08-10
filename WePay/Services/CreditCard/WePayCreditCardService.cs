using WePay.CreditCard;
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

        public virtual WePayCreditCard Get(CreditCardArguments arguments)
        {
            arguments.ClientId = arguments.ClientId.Equals(null) ? (ClientId == null ? WePayConfiguration.GetClientId() : ClientId) : arguments.ClientId;
            arguments.ClientSecret = string.IsNullOrWhiteSpace(arguments.ClientSecret) ? (string.IsNullOrWhiteSpace(ClientSecret) ? WePayConfiguration.GetClientSecret() : ClientSecret) : arguments.ClientSecret;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CreditCard, AccessToken, parameters);

            return WepayMapping<WePayCreditCard>.MapFromJson(response);
        }

        public virtual WePayCreditCard[] Find(CreditCardFindArguments arguments)
        {

            arguments.ClientId = arguments.ClientId.Equals(null) ? (ClientId == null ? WePayConfiguration.GetClientId() : ClientId) : arguments.ClientId;
            arguments.ClientSecret = string.IsNullOrWhiteSpace(arguments.ClientSecret) ? (string.IsNullOrWhiteSpace(ClientSecret) ? WePayConfiguration.GetClientSecret() : ClientSecret) : arguments.ClientSecret;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CreditCardFind, AccessToken, parameters);

            return WepayMapping<WePayCreditCard[]>.MapFromJson(response);
        }

        public virtual WePayCreditCardState Create(CreditCardCreateArguments arguments)
        {
            arguments.ClientId = arguments.ClientId.Equals(null) ? (ClientId == null ? WePayConfiguration.GetClientId() : ClientId) : arguments.ClientId;
         
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CreditCardCreate, AccessToken, parameters);

            return WepayMapping<WePayCreditCardState>.MapFromJson(response);
        }

        public virtual WePayCreditCardState Authorize(CreditCardArguments arguments)
        {
            arguments.ClientId = arguments.ClientId.Equals(null) ? (ClientId == null ? WePayConfiguration.GetClientId() : ClientId) : arguments.ClientId;
            arguments.ClientSecret = string.IsNullOrWhiteSpace(arguments.ClientSecret) ? (string.IsNullOrWhiteSpace(ClientSecret) ? WePayConfiguration.GetClientSecret() : ClientSecret) : arguments.ClientSecret;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CreditCardAuthorize, AccessToken, parameters);

            return WepayMapping<WePayCreditCardState>.MapFromJson(response);
        }

        public virtual WePayCreditCardState Delete(CreditCardArguments arguments)
        {

            arguments.ClientId = arguments.ClientId.Equals(null) ? (ClientId == null ? WePayConfiguration.GetClientId() : ClientId) : arguments.ClientId;
            arguments.ClientSecret = string.IsNullOrWhiteSpace(arguments.ClientSecret) ? (string.IsNullOrWhiteSpace(ClientSecret) ? WePayConfiguration.GetClientSecret() : ClientSecret) : arguments.ClientSecret;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CreditCardDelete, AccessToken, parameters);

            return WepayMapping<WePayCreditCardState>.MapFromJson(response);
        }

    }
}
