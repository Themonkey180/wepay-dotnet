using WePay.Account;
using WePay.Entities;
using WePay.Infrastructure;
using WePay.Services;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/account-membership
    /// </summary>
    public class WePayAccountMembershipService : WepayService
    {
        public WePayAccountMembershipService(string accessToken = null, long? accountId = null) : base(accessToken, accountId) { }

        public virtual WepayAccountMembership Create(AccountMembershipCreateArgument arguments)
        {
            arguments.AccountId = arguments.AccountId.Equals(null) ? (AccountId == null ? WePayConfiguration.GetAccountId() : AccountId) : arguments.AccountId;
            var url = Urls.AccountMembershipCreate;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return WepayMapping<WepayAccountMembership>.MapFromJson(response);
        }

        public virtual WepayAccountMembership Modify(AccountMembershipModifyArguments arguments)
        {
            arguments.AccountId = arguments.AccountId.Equals(null) ? (AccountId == null ? WePayConfiguration.GetAccountId() : AccountId) : arguments.AccountId;
            var url = Urls.AccountMembershipModify;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return WepayMapping<WepayAccountMembership>.MapFromJson(response);
        }

        public virtual WepayAccountMembership Remove(AccountMembershipRemoveArguments arguments)
        {
            arguments.AccountId = arguments.AccountId.Equals(null) ? (AccountId == null ? WePayConfiguration.GetAccountId() : AccountId) : arguments.AccountId;
            var url = Urls.AccountMembershipRemove;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return WepayMapping<WepayAccountMembership>.MapFromJson(response);
        }
    }
}
