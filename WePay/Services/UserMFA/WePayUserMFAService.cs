using WePay.Entities;
using WePay.Infrastructure;
using WePay.Services;
using WePay.UserMFA;

namespace WePay
{
    public class WePayUserMFAService : WepayService
    {
        public WePayUserMFAService(string accessToken = null) : base(accessToken) { }

        public virtual WepayMFACreate create(UserMFACreateArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.UserMfaCreate, AccessToken, parameters);

            return WepayMapping<WepayMFACreate>.MapFromJson(response);
        }

        public virtual WepayMFAValidateCookie ValidateCookie(UserMFAValidateCookieArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.UserMfacreateValidateCookie, AccessToken, parameters);

            return WepayMapping<WepayMFAValidateCookie>.MapFromJson(response);
        }

        public virtual WepayMFA SendChallenge(UserMFASendChallengeArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.UserMfaSendChallenge, AccessToken, parameters);

            return WepayMapping<WepayMFA>.MapFromJson(response);
        }

        public virtual WepayMFA SendDefaultChallenge()
        {
            var response = Requestor.PostStringBearer(Urls.UserMfaSendDefaultChallenge, AccessToken);

            return WepayMapping<WepayMFA>.MapFromJson(response);
        }

        public virtual WepayMFA Confirm(UserMFAConfirmArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.UserMfaConfirm, AccessToken, parameters);

            return WepayMapping<WepayMFA>.MapFromJson(response);
        }

        public virtual WepayMFAFind Find(UserMFAFind arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.UserMfaFind, AccessToken, parameters);

            return WepayMapping<WepayMFAFind>.MapFromJson(response);
        }

        public virtual WepayMFA Modify(UserMFAModify arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.UserMfaModify, AccessToken, parameters);

            return WepayMapping<WepayMFA>.MapFromJson(response);
        }
    }
}
