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
    /// https://www.wepay.com/developer/reference/app
    /// </summary>
    public class WePayAppService : WepayService
    {
        public WePayAppService(string accessToken = null, long? clientId = null, string ClientSecret = null) : base(accessToken, clientId, ClientSecret) { }

        public virtual WePayUserRegisterd Get(WePayAppArguments arguments)
        {
            arguments.ClientId = arguments.ClientId.Equals(null) ? (ClientId == null ? WePayConfiguration.GetClientId() : ClientId) : arguments.ClientId;
            arguments.ClientSecret = string.IsNullOrWhiteSpace(arguments.ClientSecret) ? (string.IsNullOrWhiteSpace(ClientSecret) ? WePayConfiguration.GetClientSecret() : ClientSecret) : arguments.ClientSecret;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostString(Urls.App, parameters);

            return Mapper<WePayUserRegisterd>.MapFromJson(response);
        }

        public virtual WePayUserRegisterd Modify(WePayUserRegisterArguments arguments)
        {
            arguments.ClientId = arguments.ClientId.Equals(null) ? (ClientId == null ? WePayConfiguration.GetClientId() : ClientId) : arguments.ClientId;
            arguments.ClientSecret = string.IsNullOrWhiteSpace(arguments.ClientSecret) ? (string.IsNullOrWhiteSpace(ClientSecret) ? WePayConfiguration.GetClientSecret() : ClientSecret) : arguments.ClientSecret;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostString(Urls.AppModify, parameters);

            return Mapper<WePayUserRegisterd>.MapFromJson(response);
        }
    }
}
