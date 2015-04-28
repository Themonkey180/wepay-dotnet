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
    public class WePayUserService : WepayService
    {
        public WePayUserService(string accessToken = null, long? clientId = null, string ClientSecret = null) : base(accessToken, clientId, ClientSecret) { }

        public virtual WePayUser Get()
        {
            var response = Requestor.PostStringBearer(Urls.User, AccessToken);

            return Mapper<WePayUser>.MapFromJson(response);
        }

        public virtual WePayUser Modify(WePayUserModifyArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.UserModify, AccessToken, parameters);

            return Mapper<WePayUser>.MapFromJson(response);
        }

        public virtual WePayUserRegisterd Register(WePayUserRegisterArguments arguments)
        {
            arguments.ClientId = arguments.ClientId.Equals(null) ? (ClientId == null ? WePayConfiguration.GetClientId() : ClientId) : arguments.ClientId;
            arguments.ClientSecret = string.IsNullOrWhiteSpace(arguments.ClientSecret) ? (string.IsNullOrWhiteSpace(ClientSecret) ? WePayConfiguration.GetClientSecret() : ClientSecret) : arguments.ClientSecret;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostString(Urls.UserRegister, parameters);

            return Mapper<WePayUserRegisterd>.MapFromJson(response);
        }

        public virtual WePayUserSendConfirmation SendConfirmation(WePayUserSendConfirmationArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.UserSendConfirmation, AccessToken, parameters);

            return Mapper<WePayUserSendConfirmation>.MapFromJson(response);
        }
    }
}
