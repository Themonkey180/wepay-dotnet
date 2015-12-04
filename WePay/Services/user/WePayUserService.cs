using WePay.Entities;
using WePay.Infrastructure;
using WePay.Services;
using WePay.User;

namespace WePay
{
    /// <summary>
    /// 
    /// </summary>
    public class WePayUserService : WepayService
    {
        public WePayUserService(string accessToken = null, long? clientId = null, string ClientSecret = null) : base(accessToken, clientId, ClientSecret) { }

        public WePayUserService(string accessToken = null) : base(accessToken) { }

        public virtual WePayUser Get()
        {
            var response = Requestor.PostStringBearer(Urls.User, AccessToken);

            return WepayMapping<WePayUser>.MapFromJson(response);
        }

        public virtual WePayUser Modify(UserModifyArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.UserModify, AccessToken, parameters);

            return WepayMapping<WePayUser>.MapFromJson(response);
        }

        public virtual WePayUserRegisterd Register(UserRegisterArguments arguments)
        {
            arguments.ClientId = arguments.ClientId.Equals(null) ? (ClientId == null ? WePayConfiguration.GetClientId() : ClientId) : arguments.ClientId;
            arguments.ClientSecret = string.IsNullOrWhiteSpace(arguments.ClientSecret) ? (string.IsNullOrWhiteSpace(ClientSecret) ? WePayConfiguration.GetClientSecret() : ClientSecret) : arguments.ClientSecret;

            if(string.IsNullOrWhiteSpace(arguments.Scope)){
                arguments.Scope = "collect_payments,manage_accounts,manage_subscriptions,preapprove_payments,send_money,view_user";
            }
             
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostString(Urls.UserRegister, parameters);

            return WepayMapping<WePayUserRegisterd>.MapFromJson(response);
        }

        public virtual WePayUserSendConfirmation SendConfirmation(UserSendConfirmationArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.UserSendConfirmation, AccessToken, parameters);

            return WepayMapping<WePayUserSendConfirmation>.MapFromJson(response);
        }
    }
}
