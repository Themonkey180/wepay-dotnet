using WePay.Entities;
using WePay.Infrastructure;
using WePay.Oauth2;
using WePay.Services;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/oauth2
    /// </summary>
    public class WePayOauth2Service : WepayService
    {
        public WePayOauth2Service(long? clientId = null, string ClientSecret = null) : base(clientId, ClientSecret) { }

        public virtual WePayUserRegisterd Token(Oauth2TokenArguments arguments)
        {
            arguments.ClientId = arguments.ClientId.Equals(null) ? (ClientId == null ? WePayConfiguration.GetClientId() : ClientId) : arguments.ClientId;
            arguments.ClientSecret = string.IsNullOrWhiteSpace(arguments.ClientSecret) ? (string.IsNullOrWhiteSpace(ClientSecret) ? WePayConfiguration.GetClientSecret() : ClientSecret) : arguments.ClientSecret;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostString(Urls.Oauth2Token, parameters);

            return WepayMapping<WePayUserRegisterd>.MapFromJson(response);
        }
    }
}
