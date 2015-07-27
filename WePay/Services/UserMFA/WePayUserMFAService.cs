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
            var response = Requestor.PostStringBearer(Urls.User, AccessToken, parameters);

            return Mapper<WepayMFACreate>.MapFromJson(response);
        }

        public virtual WepayMFAValidateCookie ValidateCookie(UserMFAValidateCookieArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.UserModify, AccessToken, parameters);

            return Mapper<WepayMFAValidateCookie>.MapFromJson(response);
        }

        public virtual WepayMFA SendChallenge(UserMFASendChallengeArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.UserModify, AccessToken, parameters);

            return Mapper<WepayMFA>.MapFromJson(response);
        }

        public virtual WepayMFA SendDefaultChallenge()
        {
            var response = Requestor.PostStringBearer(Urls.UserModify, AccessToken);

            return Mapper<WepayMFA>.MapFromJson(response);
        }

        public virtual WepayMFA Confirm(UserMFAConfirmArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.UserModify, AccessToken, parameters);

            return Mapper<WepayMFA>.MapFromJson(response);
        }

        public virtual WepayMFAFind Find(UserMFAFind arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.UserModify, AccessToken, parameters);

            return Mapper<WepayMFAFind>.MapFromJson(response);
        }

        public virtual WepayMFA Modify(UserMFAModify arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.UserModify, AccessToken, parameters);

            return Mapper<WepayMFA>.MapFromJson(response);
        }
    }
}
