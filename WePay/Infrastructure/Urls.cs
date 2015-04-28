using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WePay.Infrastructure
{
    class Urls
    {
        public static string User
        {
            get { return BaseUrl + "/user"; }
        }

        public static string UserModify
        {
            get { return BaseUrl + "/user/modify"; }
        }

        public static string UserRegister
        {
            get { return BaseUrl + "/user/register"; }
        }

        public static string UserSendConfirmation
        {
            get { return BaseUrl + "/user/send_confirmation"; }
        }

        public static string Account
        {
            get { return BaseUrl + "/account"; }
        }

        public static string AccountFind
        {
            get { return BaseUrl + "/account/find"; }
        }

        public static string AccountCreate
        {
            get { return BaseUrl + "/account/create"; }
        }

        public static string AccountModify
        {
            get { return BaseUrl + "/account/modify"; }
        }

        public static string AccountDelete
        {
            get { return BaseUrl + "/account/delete"; }
        }

        public static string AccountGetUpdateUri
        {
            get { return BaseUrl + "/account/get_update_uri"; }
        }

        public static string AccountGetReserveDetails
        {
            get { return BaseUrl + "/account/get_reserve_details"; }
        }

        private static string BaseUrl
        {
            get { return "https://stage.wepayapi.com/v2/"; }
        }
    }
}
