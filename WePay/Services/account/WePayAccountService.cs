using WePay.Entities;
using WePay.Infrastructure;
using WePay.Services;

namespace WePay
{
    public class WePayAccountrService : WepayService
    {
        public WePayAccountrService(string accessToken = null) : base(accessToken) { }

        public virtual WepayAccount Get(WePayAccountArguments arguments)
        {
            var url = Urls.Account;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayAccount>.MapFromJson(response);
        }

        public virtual WepayAccount[] Find(WePayFindAccountArguments arguments)
        {
            var url = Urls.AccountFind;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayAccount[]>.MapFromJson(response);
        }

        public virtual WepayAccount Create(WePayCreateAccountArgument arguments)
        {
            var url = Urls.AccountCreate;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayAccount>.MapFromJson(response);
        }

        public virtual WepayAccount Modify(WePayModifyAccountArguments arguments)
        {
            var url = Urls.AccountModify;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayAccount>.MapFromJson(response);
        }

        public virtual WePayDeletedAccount Delete(WePayDeleteAccountArguments arguments)
        {
            var url = Urls.AccountModify;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WePayDeletedAccount>.MapFromJson(response);
        }

        public virtual WepayAccountUpdatedUri GetUpdateUri(WePayGetUpdateUriAccountArguments arguments)
        {
            var url = Urls.AccountModify;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayAccountUpdatedUri>.MapFromJson(response);
        }

        public virtual WepayAccountReserveDetails GetReserveDetails(WePayGetReserveDetailsAccountArguments arguments)
        {
            var url = Urls.AccountModify;
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(url, AccessToken, parameters);

            return Mapper<WepayAccountReserveDetails>.MapFromJson(response);
        }
    }
}
