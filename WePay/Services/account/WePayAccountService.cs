using WePay.Account;
using WePay.Entities;
using WePay.Infrastructure;
using WePay.Services;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/account
    /// </summary>
    public class WePayAccountrService : WepayService
    {
        public WePayAccountrService(string accessToken = null) : base(accessToken) { }

        public virtual WepayAccount Get(AccountArguments arguments)
        {
            var url = Urls.Account;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayAccount>.MapFromJson(response);
        }

        public virtual WepayAccount[] Find(AccountFindArguments arguments)
        {
            var url = Urls.AccountFind;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayAccount[]>.MapFromJson(response);
        }

        public virtual WepayAccount Create(AccountCreateArgument arguments)
        {
            var url = Urls.AccountCreate;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayAccount>.MapFromJson(response);
        }

        public virtual WepayAccount Modify(AccountModifyArguments arguments)
        {
            var url = Urls.AccountModify;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayAccount>.MapFromJson(response);
        }

        public virtual WePayAccountState Delete(AccountDeleteArguments arguments)
        {
            var url = Urls.AccountModify;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WePayAccountState>.MapFromJson(response);
        }

        public virtual WepayAccountUpdatedUri GetUpdateUri(AccountGetUpdateUriArguments arguments)
        {
            var url = Urls.AccountModify;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayAccountUpdatedUri>.MapFromJson(response);
        }

        public virtual WepayAccountReserveDetails GetReserveDetails(AccountGetReserveDetailsArguments arguments)
        {
            var url = Urls.AccountModify;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayAccountReserveDetails>.MapFromJson(response);
        }
    }
}
