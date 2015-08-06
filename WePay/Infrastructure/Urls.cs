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
            get { return BaseUrl + "user"; }
        }

        public static string UserModify
        {
            get { return BaseUrl + "user/modify"; }
        }

        public static string UserRegister
        {
            get { return BaseUrl + "user/register"; }
        }

        public static string UserSendConfirmation
        {
            get { return BaseUrl + "user/send_confirmation"; }
        }

        public static string Account
        {
            get { return BaseUrl + "account"; }
        }

        public static string AccountFind
        {
            get { return BaseUrl + "account/find"; }
        }

        public static string AccountCreate
        {
            get { return BaseUrl + "account/create"; }
        }

        public static string AccountModify
        {
            get { return BaseUrl + "account/modify"; }
        }

        public static string AccountDelete
        {
            get { return BaseUrl + "account/delete"; }
        }

        public static string AccountGetUpdateUri
        {
            get { return BaseUrl + "account/get_update_uri"; }
        }

        public static string AccountGetReserveDetails
        {
            get { return BaseUrl + "account/get_reserve_details"; }
        }

        public static string App
        {
            get { return BaseUrl + "app"; }
        }

        public static string AppModify
        {
            get { return BaseUrl + "app/modify"; }
        }

        public static string Checkout
        {
            get { return BaseUrl + "checkout"; }
        }

        public static string CheckoutFind
        {
            get { return BaseUrl + "checkout/find"; }
        }

        public static string CheckoutCreate
        {
            get { return BaseUrl + "checkout/create"; }
        }

        public static string CheckoutCancel
        {
            get { return BaseUrl + "checkout/cancel"; }
        }

        public static string CheckoutRefund
        {
            get { return BaseUrl + "checkout/refund"; }
        }

        public static string CheckoutCapture
        {
            get { return BaseUrl + "checkout/capture"; }
        }

        public static string CheckoutModify
        {
            get { return BaseUrl + "checkout/modify"; }
        }

        public static string Preapproval
        {
            get { return BaseUrl + "preapproval"; }
        }

        public static string PreapprovalFind
        {
            get { return BaseUrl + "preapproval/find"; }
        }

        public static string PreapprovalCreate
        {
            get { return BaseUrl + "preapproval/create"; }
        }

        public static string PreapprovalCancel
        {
            get { return BaseUrl + "preapproval/cancel"; }
        }

        public static string PreapprovalModify
        {
            get { return BaseUrl + "preapproval/modify"; }
        }

        public static string Withdrawal
        {
            get { return BaseUrl + "withdrawal"; }
        }

        public static string WithdrawalFind
        {
            get { return BaseUrl + "withdrawal/find"; }
        }

        public static string WithdrawalCreate
        {
            get { return BaseUrl + "withdrawal/create"; }
        }

        public static string WithdrawalModify
        {
            get { return BaseUrl + "withdrawal/modify"; }
        }

        public static string CreditCard
        {
            get { return BaseUrl + "credit_card"; }
        }

        public static string CreditCardCreate
        {
            get { return BaseUrl + "credit_card/create"; }
        }

        public static string CreditCardAuthorize
        {
            get { return BaseUrl + "credit_card/authorize"; }
        }

        public static string CreditCardFind
        {
            get { return BaseUrl + "credit_card/find"; }
        }

        public static string CreditCardDelete
        {
            get { return BaseUrl + "credit_card/delete"; }
        }

        public static string SubscriptionPlan
        {
            get { return BaseUrl + "subscription_plan"; }
        }

        public static string SubscriptionPlanFind
        {
            get { return BaseUrl + "subscription_plan/find"; }
        }

        public static string SubscriptionPlanCreate
        {
            get { return BaseUrl + "subscription_plan/create"; }
        }

        public static string SubscriptionPlanDelete
        {
            get { return BaseUrl + "subscription_plan/delete"; }
        }

        public static string SubscriptionPlanModify
        {
            get { return BaseUrl + "subscription_plan/modify"; }
        }

        public static string Subscription
        {
            get { return BaseUrl + "subscription"; }
        }

        public static string SubscriptionFind
        {
            get { return BaseUrl + "subscription/find"; }
        }

        public static string SubscriptionCreate
        {
            get { return BaseUrl + "subscription/create"; }
        }

        public static string SubscriptionCancel
        {
            get { return BaseUrl + "subscription/cancel"; }
        }

        public static string SubscriptionModify
        {
            get { return BaseUrl + "subscription/modify"; }
        }

        public static string SubscriptionCharge
        {
            get { return BaseUrl + "subscription_charge"; }
        }

        public static string SubscriptionChargeFind
        {
            get { return BaseUrl + "subscription_charge/find"; }
        }

        public static string SubscriptionChargeRefund
        {
            get { return BaseUrl + "subscription_charge/refund"; }
        }

        public static string AccountMembershipCreate
        {
            get { return BaseUrl + "account/membership/create"; }
        }

        public static string AccountMembershipModify
        {
            get { return BaseUrl + "account/membership/modify"; }
        }

        public static string AccountMembershipRemove
        {
            get { return BaseUrl + "account/membership/remove"; }
        }

        public static string UserMfaCreate
        {
            get { return BaseUrl + "user/mfa/create"; }
        }

        public static string UserMfacreateValidateCookie
        {
            get { return BaseUrl + "user/mfa/validate_cookie"; }
        }

        public static string UserMfaSendChallenge
        {
            get { return BaseUrl + "user/mfa/send_challenge"; }
        }

        public static string UserMfaSendDefaultChallenge
        {
            get { return BaseUrl + "user/mfa/SendDefaultChallenge"; }
        }

        public static string UserMfaConfirm
        {
            get { return BaseUrl + "user/mfa/confirm"; }
        }

        public static string UserMfaFind
        {
            get { return BaseUrl + "user/mfa/find"; }
        }

        public static string UserMfaModify
        {
            get { return BaseUrl + "user/mfa/modify"; }
        }

        public static string Oauth2Token
        {
            get { return BaseUrl + "oauth2/token"; }
        }

        public static string BatchCreate
        {
            get { return BaseUrl + "batch/create"; }
        }

        public static string RbitGet
        {
            get { return BaseUrl + "rbit"; }
        }

        public static string RbitFind
        {
            get { return BaseUrl + "rbit/find"; }
        }

        public static string RbitCreate
        {
            get { return BaseUrl + "rbit/create"; }
        }

        public static string RbitDelete
        {
            get { return BaseUrl + "rbit/delete"; }
        }


        private static string BaseUrl
        {
            get
            {
                if (WePayConfiguration.GetProductionMode())
                {
                    return "https://wepayapi.com/v2/";
                }
                else
                {
                    return "https://stage.wepayapi.com/v2/";
                }
            }
        }
    }
}
