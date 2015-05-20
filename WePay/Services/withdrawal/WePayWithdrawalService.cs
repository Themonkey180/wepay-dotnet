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
        public WePayWithdrawalService(string accessToken = null) : base(accessToken) { }

        public virtual WePayWithdrawal Get(WithdrawalArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.Withdrawal, AccessToken, parameters);

            return Mapper<WePayWithdrawal>.MapFromJson(response);
        }

        public virtual WePayWithdrawal[] Find(WithdrawalFindArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.WithdrawalFind, AccessToken, parameters);

            return Mapper<WePayWithdrawal[]>.MapFromJson(response);
        }

        public virtual WePayWithdrawalCreated Create(WithdrawalCreateArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.WithdrawalCreate, AccessToken, parameters);

            return Mapper<WePayWithdrawalCreated>.MapFromJson(response);
        }

        public virtual WePayWithdrawal Modify(WithdrawalModifyArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.WithdrawalModify, AccessToken, parameters);

            return Mapper<WePayWithdrawal>.MapFromJson(response);
        }

    }
}
