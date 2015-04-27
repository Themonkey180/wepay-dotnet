using System;
using System.Configuration;

namespace WePay
{
    public static class WePayConfiguration
    {
        internal const string SupportedApiVersion = "2014-01-08";
        private static bool _ProductionMode = false;
        private static string _ClientSecret;
        private static string _ClientId;
        private static string _AccessToken;
        private static string _authScope = "manage_accounts,collect_payments,view_user,preapprove_payments,manage_subscriptions,send_money";

        static WePayConfiguration()
        {
            ApiVersion = SupportedApiVersion;
        }

        #region ClientSecret
        internal static string GetClientSecret()
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
        internal static string GetClientId()
        {
            if (string.IsNullOrEmpty(_ClientSecret))
                _ClientId = ConfigurationManager.AppSettings["WepayClientId"];

            return _ClientId;
        }

        public static void SetClientId(string newClientId)
        {
            _ClientId = newClientId;
        }
         #endregion

        #region AccessToken
        internal static string GetAccessToken()
        {
            if (string.IsNullOrEmpty(_ClientSecret))
                _AccessToken = ConfigurationManager.AppSettings["WepayAccessToken"];

            return _AccessToken;
        }

        public static void SetAccessToken(string newAccessToken)
        {
            _AccessToken = newAccessToken;
        }
        #endregion

        #region ProductionMode
        internal static bool GetProductionMode()
        {
            if (string.IsNullOrEmpty(_ClientSecret))
                bool.TryParse(ConfigurationManager.AppSettings["ProductionMode"], out _ProductionMode);

            return _ProductionMode;
        }

        public static void SetClientId(bool newProductionMode)
        {
            _ProductionMode = newProductionMode;
        }
         #endregion

        public static string ApiVersion { get; internal set; }
    }
}