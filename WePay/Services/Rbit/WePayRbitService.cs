using WePay.Account;
using WePay.Entities;
using WePay.Infrastructure;
using WePay.Services;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/account-membership
    /// </summary>
    public class WePayRbitService : WepayService
    {
        public WePayRbitService(string accessToken = null, long? accountId = null) : base(accessToken, accountId) { }

        public virtual WepayAccountMembership Get(AccountMembershipCreateArgument arguments)
        {
            var url = Urls.AccountMembershipCreate;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayAccountMembership>.MapFromJson(response);
        }

        public virtual WepayAccountMembership Create(AccountMembershipCreateArgument arguments)
        {
            var url = Urls.AccountMembershipCreate;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayAccountMembership>.MapFromJson(response);
        }

        public virtual WepayAccountMembership Modify(AccountMembershipModifyArguments arguments)
        {
            var url = Urls.AccountMembershipModify;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayAccountMembership>.MapFromJson(response);
        }

        public virtual WepayAccountMembership Remove(AccountMembershipRemoveArguments arguments)
        {
            var url = Urls.AccountMembershipRemove;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayAccountMembership>.MapFromJson(response);
        }
    }
}
