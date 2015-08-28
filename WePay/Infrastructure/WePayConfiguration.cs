using System;
using System.Configuration;

namespace WePay
{
    public static class WePayConfiguration
    {
        internal const string SupportedApiVersion = "2014-01-08";
        private static bool _ProductionMode = false;
        private static string _ClientSecret;
        private static long _ClientId;
        private static string _AccessToken;
        private static long _AccountId;
 
        static WePayConfiguration()
        {
            ApiVersion = SupportedApiVersion;
        }

        #region ClientSecret
        public static string GetClientSecret()
        {
            if (string.IsNullOrEmpty(_ClientSecret))
                _ClientSecret = ConfigurationManager.AppSettings["WepayClientSecret"];

            return _ClientSecret;
        }

        public static void SetClientSecret(string newClientSecret)
        {
            _ClientSecret = newClientSecret;
        }
        #endregion

        #region ClientId
        public static long GetClientId()
        {

            if (_ClientId == null || _ClientId == 0)
                long.TryParse(ConfigurationManager.AppSettings["WepayClientId"], out _ClientId);

            return _ClientId;
        }

        public static void SetClientId(long newClientId)
        {
            _ClientId = newClientId;
        }
         #endregion

        #region AccessToken
        public static string GetAccessToken()
        {
            if (string.IsNullOrEmpty(_AccessToken))
                _AccessToken = ConfigurationManager.AppSettings["WepayAccessToken"];

            return _AccessToken;
        }

        public static void SetAccessToken(string newAccessToken)
        {
            _AccessToken = newAccessToken;
        }
        #endregion

        #region AccountId
        public static long GetAccountId()
        {
            if (_AccountId == null || _AccountId == 0)
                long.TryParse(ConfigurationManager.AppSettings["WepayAccountId"], out _AccountId);

            return _AccountId;
        }

        public static void SetAccountId(long newAccountId)
        {
            _AccountId = newAccountId;
        }
        #endregion

        #region ProductionMode
        public static bool GetProductionMode()
        {
            if (_ProductionMode == null)
            {
                string value = ConfigurationManager.AppSettings["WepayProductionMode"];

                if (!string.IsNullOrWhiteSpace(value))
                {
                    bool answer;
                    if (bool.TryParse(value, out answer))
                    {
                        _ProductionMode = answer;
                    }
                    else
                    {
                        _ProductionMode = false;
                    }
                }
            }

            return (bool)_ProductionMode;
        }

        public static void SetProductionMode(bool newProductionMode)
        {
            _ProductionMode = newProductionMode;
        }
        #endregion

        public static string ApiVersion { get; internal set; }
    }
}