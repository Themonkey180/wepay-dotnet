using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WePay.Services
{
    public class WepayService
    {
        public string AccessToken { get; set; }
        public string ClientSecret { get; set; }
        public long? ClientId { get; set; }
        public long? AccountId { get; set; }

        public WepayService(string accessToken,long? clientId,string clientSecret)
        {
            AccessToken = accessToken;
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public WepayService(long? clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public WepayService(string accessToken, long? accountId)
        {
            AccountId = accountId;
            AccessToken = accessToken;
        }

        public WepayService(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
