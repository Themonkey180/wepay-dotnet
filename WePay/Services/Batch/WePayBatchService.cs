using System.Collections.Generic;
using WePay.Batch;
using WePay.Entities;
using WePay.Infrastructure;
using WePay.Services;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/batch
    /// </summary>
    public class WePayBatchService : WepayService
    {
        public WePayBatchService(string accessToken = null, long? clientId = null, string ClientSecret = null) : base(accessToken, clientId, ClientSecret) { }

        public virtual List<WepayBatch> Create(BatchArguments arguments)
        {
            arguments.ClientId = arguments.ClientId.Equals(null) ? (ClientId == null ? WePayConfiguration.GetClientId() : ClientId) : arguments.ClientId;
            arguments.ClientSecret = string.IsNullOrWhiteSpace(arguments.ClientSecret) ? (string.IsNullOrWhiteSpace(ClientSecret) ? WePayConfiguration.GetClientSecret() : ClientSecret) : arguments.ClientSecret;

            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.BatchCreate, AccessToken, parameters);

            return WepayMapping.MapBatchFromJson(response).Result;
        }
    }
}
