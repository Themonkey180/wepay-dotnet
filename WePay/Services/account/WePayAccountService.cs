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
        public WePayAccountrService(string accessToken = null, long? accountId = null) : base(accessToken, accountId) { }
        public WePayAccountrService(string accessToken = null) : base(accessToken) { }

        public virtual WepayAccount Get(AccountArguments arguments)
        {
            arguments.AccountId = arguments.AccountId.Equals(null) ? (AccountId == null ? WePayConfiguration.GetAccountId() : AccountId) : arguments.AccountId;
           
            var url = Urls.Account;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return WepayMapping<WepayAccount>.MapFromJson(response);
        }

        public virtual WepayAccount[] Find(AccountFindArguments arguments)
        {
            var url = Urls.AccountFind;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return WepayMapping<WepayAccount[]>.MapFromJson(response);
        }

        public virtual WepayAccount Create(AccountCreateArgument arguments)
        {
            var url = Urls.AccountCreate;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return WepayMapping<WepayAccount>.MapFromJson(response);
        }

        public virtual WepayAccount Modify(AccountModifyArguments arguments)
        {
            arguments.AccountId = arguments.AccountId.Equals(null) ? (AccountId == null ? WePayConfiguration.GetAccountId() : AccountId) : arguments.AccountId;
           
            var url = Urls.AccountModify;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return WepayMapping<WepayAccount>.MapFromJson(response);
        }

        public virtual WePayAccountState Delete(AccountDeleteArguments arguments)
        {
            arguments.AccountId = arguments.AccountId.Equals(null) ? (AccountId == null ? WePayConfiguration.GetAccountId() : AccountId) : arguments.AccountId;
           
            var url = Urls.AccountModify;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return WepayMapping<WePayAccountState>.MapFromJson(response);
        }

        public virtual WepayAccountUpdatedUri GetUpdateUri(AccountGetUpdateUriArguments arguments)
        {
            arguments.AccountId = arguments.AccountId.Equals(null) ? (AccountId == null ? WePayConfiguration.GetAccountId() : AccountId) : arguments.AccountId;
           
            var url = Urls.AccountModify;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return WepayMapping<WepayAccountUpdatedUri>.MapFromJson(response);
        }

        public virtual WepayAccountReserveDetails GetReserveDetails(AccountGetReserveDetailsArguments arguments)
        {
            arguments.AccountId = arguments.AccountId.Equals(null) ? (AccountId == null ? WePayConfiguration.GetAccountId() : AccountId) : arguments.AccountId;
           
            var url = Urls.AccountModify;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return WepayMapping<WepayAccountReserveDetails>.MapFromJson(response);
        }
    }
}
