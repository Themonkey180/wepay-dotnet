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
    /// https://www.wepay.com/developer/reference/withdrawal
    /// </summary>
    public class WePayWithdrawalService : WepayService
    {
        public WePayWithdrawalService(string accessToken = null) : base(accessToken) { }

        public virtual WePayWithdrawal Get(WePayWithdrawalArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.Withdrawal, AccessToken, parameters);

            return Mapper<WePayWithdrawal>.MapFromJson(response);
        }

        public virtual WePayWithdrawal[] Find(WePayWithdrawalFindArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.WithdrawalFind, AccessToken, parameters);

            return Mapper<WePayWithdrawal[]>.MapFromJson(response);
        }

        public virtual WePayWithdrawalCreated Create(WePayWithdrawalCreateArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.WithdrawalCreate, AccessToken, parameters);

            return Mapper<WePayWithdrawalCreated>.MapFromJson(response);
        }

        public virtual WePayWithdrawal Modify(WePayWithdrawalModifyArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.WithdrawalModify, AccessToken, parameters);

            return Mapper<WePayWithdrawal>.MapFromJson(response);
        }

    }
}
