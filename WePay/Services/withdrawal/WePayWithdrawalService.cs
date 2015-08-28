using WePay.Entities;
using WePay.Infrastructure;
using WePay.Services;
using WePay.Withdrawal;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/withdrawal
    /// </summary>
    public class WePayWithdrawalService : WepayService
    {
        public WePayWithdrawalService(string accessToken = null, long? accountId = null) : base(accessToken, accountId) { }

        public virtual WePayWithdrawal Get(WithdrawalArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.Withdrawal, AccessToken, parameters);

            return WepayMapping<WePayWithdrawal>.MapFromJson(response);
        }

        public virtual WePayWithdrawal[] Find(WithdrawalFindArguments arguments)
        {
            arguments.AccountId = arguments.AccountId.Equals(null) ? (AccountId == null ? WePayConfiguration.GetAccountId() : AccountId) : arguments.AccountId;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.WithdrawalFind, AccessToken, parameters);

            return WepayMapping<WePayWithdrawal[]>.MapFromJson(response);
        }

        public virtual WePayWithdrawalCreated Create(WithdrawalCreateArguments arguments)
        {
            arguments.AccountId = arguments.AccountId.Equals(null) ? (AccountId == null ? WePayConfiguration.GetAccountId() : AccountId) : arguments.AccountId;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.WithdrawalCreate, AccessToken, parameters);

            return WepayMapping<WePayWithdrawalCreated>.MapFromJson(response);
        }

        public virtual WePayWithdrawal Modify(WithdrawalModifyArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.WithdrawalModify, AccessToken, parameters);

            return WepayMapping<WePayWithdrawal>.MapFromJson(response);
        }

    }
}
