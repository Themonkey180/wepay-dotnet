using WePay.Entities;
using WePay.Infrastructure;
using WePay.Preapproval;
using WePay.Services;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/preapproval
    /// </summary>
    public class WePayPreapprovalService : WepayService
    {
        public WePayPreapprovalService(string accessToken = null, long? accountId = null) : base(accessToken, accountId) { }

        public virtual WePayPreapproval Get(PreapprovalArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.Preapproval, AccessToken, parameters);

            return Mapper<WePayPreapproval>.MapFromJson(response);
        }

        public virtual WePayPreapproval[] Find(PreapprovalFindArguments arguments)
        {
            arguments.AccountId = arguments.AccountId.Equals(null) ? (AccountId == null ? WePayConfiguration.GetAccountId() : AccountId) : arguments.AccountId;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.PreapprovalFind, AccessToken, parameters);

            return Mapper<WePayPreapproval[]>.MapFromJson(response);
        }

        public virtual WePayPreapprovalCreate Create(PreapprovalCreateArguments arguments)
        {
            arguments.AccountId = arguments.AccountId.Equals(null) ? (AccountId == null ? WePayConfiguration.GetAccountId() : AccountId) : arguments.AccountId;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.PreapprovalCreate, AccessToken, parameters);

            return Mapper<WePayPreapprovalCreate>.MapFromJson(response);
        }

        public virtual WePayPreapprovalState Cancel(PreapprovalArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.PreapprovalCancel, AccessToken, parameters);

            return Mapper<WePayPreapprovalState>.MapFromJson(response);
        }

        public virtual WePayPreapproval Modify(PreapprovalModifyArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.PreapprovalModify, AccessToken, parameters);

            return Mapper<WePayPreapproval>.MapFromJson(response);
        }
       
    }
}
