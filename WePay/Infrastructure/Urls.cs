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

        public static string App
        {
            get { return BaseUrl + "/app"; }
        }

        public static string AppModify
        {
            get { return BaseUrl + "/app/modify"; }
        }

        public static string Checkout
        {
            get { return BaseUrl + "/checkout"; }
        }

        public static string CheckoutFind
        {
            get { return BaseUrl + "/checkout/find"; }
        }

        public static string CheckoutCreate
        {
            get { return BaseUrl + "/checkout/create"; }
        }

        public static string CheckoutCancel
        {
            get { return BaseUrl + "/checkout/cancel"; }
        }

        public static string CheckoutRefund
        {
            get { return BaseUrl + "/checkout/refund"; }
        }

        public static string CheckoutCapture
        {
            get { return BaseUrl + "/checkout/capture"; }
        }

        public static string CheckoutModify
        {
            get { return BaseUrl + "/checkout/modify"; }
        }

        public static string Preapproval
        {
            get { return BaseUrl + "/preapproval"; }
        }

        public static string PreapprovalFind
        {
            get { return BaseUrl + "/preapproval/find"; }
        }

        public static string PreapprovalCreate
        {
            get { return BaseUrl + "/preapproval/create"; }
        }

        public static string PreapprovalCancel
        {
            get { return BaseUrl + "/preapproval/cancel"; }
        }

        public static string PreapprovalModify
        {
            get { return BaseUrl + "/preapproval/modify"; }
        }

        private static string BaseUrl
        {
            get { return "https://stage.wepayapi.com/v2/"; }
        }
    }
}
