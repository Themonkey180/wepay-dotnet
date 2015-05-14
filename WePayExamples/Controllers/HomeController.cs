using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Text;
using System.Configuration;
using WePay;
using WePay.Infrastructure;
using WePay.Entities;
using WePay.Entities.Structure;

namespace Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUser()
        {
            var accessToken = Request.Form["accessToken"];
            WePay.WePayConfiguration.SetAccessToken(accessToken);
            var wePayUserService = new WePay.WePayUserService(accessToken);
            var wePayUser = wePayUserService.Get();

            return View(wePayUser);
        }

        public ActionResult GetAccount()
        {
            long AccountId = 0;
            var accessToken = Request.Form["accessToken"];
            long.TryParse(Request.Form["AccountId"], out AccountId);
            WePay.WePayConfiguration.SetAccessToken(accessToken);
            var wePayAccountService = new WePay.WePayAccountrService(accessToken);
            var wePayAccount = wePayAccountService.Get(new WePayAccountArguments { AccountId = AccountId });

            return View(wePayAccount);
        }

        public ActionResult FindAccount()
        {
            var name = Request.Form["name"];
            var referenceId = Request.Form["referenceId"];
            var sortOrder = Request.Form["sortOrder"];
            var accessToken = Request.Form["accessToken"];

            var wePayAccountService = new WePay.WePayAccountrService(accessToken);
            var wePayAccount = wePayAccountService.Find(new WePayFindAccountArguments { Name = name, ReferenceId = referenceId, SortOrder = sortOrder });

            return View(wePayAccount);
        }

        public ActionResult TestAll()
        {
            #region Variables

            var clientSecret = Request.Form["clientSecret"];
            long clientId = 0;
            long.TryParse(Request.Form["clientId"], out clientId);

            var email = Request.Form["email"];
            var firstName = Request.Form["firstName"];
            var lastName = Request.Form["lastName"];
            var callbackUri = Request.Form["callbackUri"];

            var userAgent = Request.UserAgent;
            var IPAddress = GetIPAddress();

           WepayAddress Address1 = new WepayAddress { Address1 = "605 Seward Ave NW", City="Grand Rapids", State="MI", Zip="49504", Country="US" };

            #endregion

            #region SetUp

                #region User

                var wePayUserService = new WePay.WePayUserService(null, clientId, clientSecret);

                var ParametersRegister = new WePayUserRegisterArguments { 
                    ClientId = clientId, 
                    ClientSecret = clientSecret, 
                    Email = email,
                    Scope = "manage_accounts,collect_payments,view_user,preapprove_payments,manage_subscriptions,send_money",
                    FirstName = firstName,
                    LastName = lastName,
                    OriginalIp = IPAddress,
                    OriginalDevice = userAgent,
                    TOSAcceptanceTime = DateTime.Now
                };

                WePayUserRegisterd user = wePayUserService.Register(ParametersRegister);
                #endregion

                #region Accounts

                var wePayAccountService = new WePay.WePayAccountrService(user.AccessToken);
                WepayAccount account = wePayAccountService.Create(new WePayCreateAccountArgument
                {
                    Name = "SDK Test",
                    Description = "An account that is a test made one.",
                    ReferenceId = "abc123",
                    Type = "personal",
                    ImageUri = "http://www.payitsquare.com/content/img/design/logo.png",
                    mcc = 7299,
                    Country = "US",
                    currencies = new string[] { "USD" }
                });

                WepayAccount accountDelete = wePayAccountService.Create(new WePayCreateAccountArgument { Name = "SDK Test delete", Description = "An account that is a test made one to delete." });
                #endregion

                #region CreditCard

                var wePayCreditCardService = new WePay.WePayCreditCardService(user.AccessToken);
                var CreditCard = wePayCreditCardService.Create(new WePayCreditCardCreateArguments
                {
                    ClientId = clientId,
                    CCnumber = "4003830171874018",
                    CVV = 123,
                    ExpirationMonth = 12,
                    ExpirationYear = 25,
                    FullName = "John Smith",
                    Email = "Test@test.com",
                    Address = Address1,
                    OriginalIp = IPAddress,
                    OriginalDevice = userAgent
                });

                var CreditCardDelete = wePayCreditCardService.Create(new WePayCreditCardCreateArguments
                {
                    ClientId = clientId,
                    CCnumber = "5496198584584769",
                    CVV = 123,
                    ExpirationMonth = 12,
                    ExpirationYear = 25,
                    FullName = "Jan Smith",
                    Email = "Test@test.com",
                    Address = Address1,
                    OriginalIp = IPAddress,
                    OriginalDevice = userAgent
                });

                 var CreditCardAuthorize = wePayCreditCardService.Create(new WePayCreditCardCreateArguments
                {
                    ClientId = clientId,
                    CCnumber = "5496198584584769",
                    CVV = 123,
                    ExpirationMonth = 12,
                    ExpirationYear = 25,
                    FullName = "Jim Smith",
                    Email = "Test@test.com",
                    Address = Address1,
                    OriginalIp = IPAddress,
                    OriginalDevice = userAgent
                });
                #endregion

                #region Preapproval

                var wePayPreapprovalService = new WePay.WePayPreapprovalService(user.AccessToken);
                var Preapproval = wePayPreapprovalService.Create(new WePayPreapprovalCreateArguments
                {
                    AccountId = account.AccountId,
                    ShortDescription = "Test a checkout Preapproval",
                    Amount = (decimal)100.75,
                    Currency = "USD",
                    AppFee = (decimal)3.02,
                    Period = "once",
                    Frequency = 1,
                    FeePayer = "payee",
                    PayerEmailMessage = "Thank you for the money.",
                    PaymentMethodId = CreditCard.CreditCardId,
                    PaymentMethodType = "credit_card"
                });

                var PreapprovalCancel = wePayPreapprovalService.Create(new WePayPreapprovalCreateArguments
                {
                    AccountId = account.AccountId,
                    ShortDescription = "Test a checkout Preapproval Cancel",
                    Amount = (decimal)100.75,
                    Currency = "USD",
                    AppFee = (decimal)3.02,
                    Period = "once",
                    Frequency = 1,
                    FeePayer = "payee",
                    PayerEmailMessage = "Thank you for the money.",
                    PaymentMethodId = CreditCard.CreditCardId,
                    PaymentMethodType = "credit_card"
                });

                #endregion

                #region Checkout

                var wePayCheckoutService = new WePay.WePayCheckoutService(user.AccessToken);
                var checkout = wePayCheckoutService.Create(new WePayCheckoutCreateArguments
                {
                    AccountId = account.AccountId,
                    ShortDescription = "Test a checkout",
                    Type = "PERSONAL",
                    Amount = (decimal)100.75,
                    Currency = "USD",
                    AppFee = (decimal)3.02,
                    FeePayer = "payee",
                    PayeeEmailMessage = "You have just got money.",
                    PayerEmailMessage = "Thank you for the money.",
                    PaymentMethodId = CreditCard.CreditCardId,
                    PaymentMethodType = "credit_card"
                });

                var checkoutCancel = wePayCheckoutService.Create(new WePayCheckoutCreateArguments
                {
                    AccountId = account.AccountId,
                    ShortDescription = "Test a checkout",
                    Type = "PERSONAL",
                    Amount = (decimal)100.75,
                    Currency = "USD",
                    AppFee = (decimal)3.02,
                    FeePayer = "payee",
                    PayeeEmailMessage = "You have just got money.",
                    PayerEmailMessage = "Thank you for the money.",
                    PreapprovalId = Preapproval.PreapprovalId,
                    PaymentMethodId = CreditCard.CreditCardId,
                    PaymentMethodType = "credit_card"
                });

                var checkoutRefund = wePayCheckoutService.Create(new WePayCheckoutCreateArguments
                {
                    AccountId = account.AccountId,
                    ShortDescription = "Test a checkout",
                    Type = "PERSONAL",
                    Amount = (decimal)100.75,
                    Currency = "USD",
                    AppFee = (decimal)3.02,
                    FeePayer = "payee",
                    PayeeEmailMessage = "You have just got money.",
                    PayerEmailMessage = "Thank you for the money.",
                    PaymentMethodId = CreditCard.CreditCardId,
                    PaymentMethodType = "credit_card"
                });
                #endregion

                #region Subscription Plan

                var wePaySubscriptionPlanService = new WePay.WePaySubscriptionPlanService(user.AccessToken);
                var SubsPlan = wePaySubscriptionPlanService.Create(new WePaySubscriptionPlanCreateArguments
                {
                    AccountId = account.AccountId,
                    ShortDescription = "Test a Subscription Plan",
                    Name = "Test a Subscription Plan",
                    Amount = (decimal)100.75,
                    Currency = "USD",
                    AppFee = (decimal)3.02,
                    Period = "monthly",
                    SetupFee = (decimal)0.50
                });

                var SubsPlanDelete = wePaySubscriptionPlanService.Create(new WePaySubscriptionPlanCreateArguments
                {
                    AccountId = account.AccountId,
                    ShortDescription = "Test a Subscription Plan delete",
                    Name = "Test a Subscription Plan delete",
                    Amount = (decimal)100.75,
                    Currency = "USD",
                    AppFee = (decimal)3.02,
                    Period = "monthly",
                    SetupFee = (decimal)0.50
                });

                #endregion

                #region Subscription

                var wePaySubscriptionService = new WePay.WePaySubscriptionService(user.AccessToken);
                var Subs = wePaySubscriptionService.Create(new WePaySubscriptionCreateArguments
                {
                    SubscriptionPlanId = SubsPlan.SubscriptionPlanId,
                    PaymentMethodId = CreditCard.CreditCardId,
                    PaymentMethodType = "credit_card"
                });

                var SubsCancel = wePaySubscriptionService.Create(new WePaySubscriptionCreateArguments
                {
                    SubscriptionPlanId = SubsPlanDelete.SubscriptionPlanId,
                    PaymentMethodId = CreditCard.CreditCardId,
                    PaymentMethodType = "credit_card"

                });

                #endregion

                #region Subscription Charge

                var wePaySubscriptionChargeService = new WePay.WePaySubscriptionChargeService(user.AccessToken);
                var SubsCharge = wePaySubscriptionChargeService.Find(new WePaySubscriptionChargeFindArguments
                {
                    SubscriptionId = Subs.SubscriptionId
                });

                #endregion

                #region Withdrawal
                WePayWithdrawalCreated withdrawal = new WePayWithdrawalCreated();
                    try { 
                        var wePayWithdrawalService = new WePay.WePayWithdrawalService(user.AccessToken);
                        withdrawal = wePayWithdrawalService.Create(new WePayWithdrawalCreateArguments
                        {
                            AccountId = account.AccountId 
                        });
                    }
                    catch
                    {

                    }

                #endregion

            #endregion

            #region Batch

                WePayBatchService wePayBatchService = new WePay.WePayBatchService(user.AccessToken, clientId, clientSecret);

                #region BatchArguments

                    #region User
                    var UserSendConfirmation = new WePayUserSendConfirmationArguments { EmailMessage = "Test From Wepay SDK. Made by Pay it Square team." };
                    var UserModify = new WePayUserModifyArguments { CallbackUri = callbackUri };
                    #endregion

                    #region App
                    var AppParameters = new WePayAppArguments { ClientId = clientId, ClientSecret = clientSecret };
                    var AppsModify = new WePayAppModifyArguments { ClientId = clientId, ClientSecret = clientSecret};
                    #endregion

                    #region Account
                    var AccountParameters = new WePayAccountArguments { AccountId = account.AccountId };
                    var AccountFindParameters = new WePayFindAccountArguments { SortOrder = "ASC" };
                    var AccountModifyParameters = new WePayModifyAccountArguments { AccountId = account.AccountId, Description = "SDK test modify" };
                    var AccountGetReserveDetailsParameters = new WePayGetReserveDetailsAccountArguments { AccountId = account.AccountId };
                    var AccountUpdateUriParameters = new WePayGetUpdateUriAccountArguments { AccountId = account.AccountId };
                    var AccountDeleteParameters = new WePayDeleteAccountArguments { AccountId = accountDelete.AccountId, Reason = "Test for delete" };
                    #endregion

                    #region CreditCard
                    var CreditCardParameters = new WePayCreditCardArguments { ClientId = clientId, ClientSecret = clientSecret, CreditCardId = CreditCard.CreditCardId };
                    var CreditCardFindParameters = new WePayCreditCardFindArguments { ClientId = clientId, ClientSecret = clientSecret };
                    var CreditCardAuthorizeParameters = new WePayCreditCardArguments { ClientId = clientId, ClientSecret = clientSecret, CreditCardId = CreditCardAuthorize.CreditCardId };
                    var CreditCardDeleteParameters = new WePayCreditCardArguments { ClientId = clientId, ClientSecret = clientSecret, CreditCardId = CreditCardDelete.CreditCardId };
                    #endregion

                    #region preapproval
                    var PreapprovalParameters = new WePayPreapprovalArguments { PreapprovalId = Preapproval.PreapprovalId };
                    var PreapprovalFindParameters = new WePayPreapprovalFindArguments { AccountId = account.AccountId };
                    var PreapprovalModifyParameters = new WePayPreapprovalModifyArguments { PreapprovalId = Preapproval.PreapprovalId };
                    var PreapprovalCancelParameters = new WePayPreapprovalArguments { PreapprovalId = PreapprovalCancel.PreapprovalId };
                    #endregion

                    #region Checkout
                    var CheckoutParameters = new WePayCheckoutArguments { CheckoutId = checkout.CheckoutId };
                    var CheckoutFindParameters = new WePayCheckoutFindArguments { AccountId = account.AccountId };
                    var CheckoutModifyParameters = new WePayCheckoutModifyArguments { CheckoutId = checkout.CheckoutId };
                    var CheckoutCancelParameters = new WePayCheckoutCancelArguments { CheckoutId = checkoutCancel.CheckoutId, CancelReason = "To test the sdk" };
                    var CheckoutRefundParameters = new WePayCheckoutRefundArguments { CheckoutId = checkoutRefund.CheckoutId };
                    #endregion

                    #region Subscription Plan
                    var SubPlanParameters = new WePaySubscriptionPlanArguments { SubscriptionPlanId = SubsPlan.SubscriptionPlanId };
                    var SubPlanFindParameters = new WePaySubscriptionPlanFindArguments { AccountId = account.AccountId };
                    var SubPlanModifyParameters = new WePaySubscriptionPlanModifyeArguments { SubscriptionPlanId = SubsPlan.SubscriptionPlanId };
                    var SubPlanDeleteParameters = new WePaySubscriptionPlanDeleteArguments { SubscriptionPlanId = SubsPlanDelete.SubscriptionPlanId, reason = "Test the delete." };
                    #endregion

                    #region Subscription
                    var SubParameters = new WePaySubscriptionArguments { SubscriptionId = Subs.SubscriptionId };
                    var SubFindParameters = new WePaySubscriptionFindArguments { SubscriptionPlanId = SubsPlan.SubscriptionPlanId };
                    var SubModifyParameters = new WePaySubscriptionModifyArguments { SubscriptionId = Subs.SubscriptionId };
                    var SubCancelParameters = new WePaySubscriptionCancelArguments { SubscriptionId = SubsCancel.SubscriptionId, Reason = "Testing the Cancel" };
                    #endregion

                    #region Subscription Charge
                    var SubChargeParameters = new WePaySubscriptionChargeArguments { subscriptionChargeId = SubsCharge[0].SubscriptionChargeId };
                    var SubChargeRefundParameters = new WePaySubscriptionChargeRefundArguments { SubscriptionChargeId = SubsCharge[0].SubscriptionChargeId, Reason = "Test the Refund" };
                    #endregion

                    #region Withdrawal
                    var WithdrawalParameters = new WePayWithdrawalArguments { WithdrawalId = withdrawal.WithdrawalId };
                    var WithdrawalFindParameters = new WePayWithdrawalFindArguments { AccountId = account.AccountId };
                    var WithdrawalModifyParameters = new WePayWithdrawalModifyArguments { WithdrawalId = withdrawal.WithdrawalId };
                    #endregion

                #endregion

                #region BatchCalls

                var batchCalls = wePayBatchService.Create(new BatchArguments 
                {
                    Calls = new BatchCallsArguments[37] { 

                        #region User
                        new BatchCallsArguments { Call = "/user", Authorization = user.AccessToken, ReferenceId = "1" }, 
                        new BatchCallsArguments { Call = UserSendConfirmation.BatchUrl(), ReferenceId = "2", Authorization = user.AccessToken, Parameters = UserSendConfirmation },
                        new BatchCallsArguments { Call = UserModify.BatchUrl(), ReferenceId = "3", Authorization = user.AccessToken, Parameters = UserModify },
                        #endregion

                        #region App
                        new BatchCallsArguments { Call = AppParameters.BatchUrl(), Authorization = user.AccessToken, ReferenceId = "4", Parameters = AppParameters }, 
                        new BatchCallsArguments { Call = AppsModify.BatchUrl(), ReferenceId = "5", Authorization = user.AccessToken, Parameters = AppsModify },
                        #endregion

                        #region Account
                        new BatchCallsArguments { Call = AccountParameters.BatchUrl(), Authorization = user.AccessToken, ReferenceId = "6", Parameters = AccountParameters }, 
                        new BatchCallsArguments { Call = AccountFindParameters.BatchUrl(), ReferenceId = "7", Authorization = user.AccessToken, Parameters = AccountFindParameters },
                        new BatchCallsArguments { Call = AccountModifyParameters.BatchUrl(), ReferenceId = "8", Authorization = user.AccessToken, Parameters = AccountModifyParameters },
                        new BatchCallsArguments { Call = AccountGetReserveDetailsParameters.BatchUrl(), ReferenceId = "9", Authorization = user.AccessToken, Parameters = AccountGetReserveDetailsParameters },
                        new BatchCallsArguments { Call = AccountUpdateUriParameters.BatchUrl(), ReferenceId = "10", Authorization = user.AccessToken, Parameters = AccountUpdateUriParameters },
                        new BatchCallsArguments { Call = AccountDeleteParameters.BatchUrl(), ReferenceId = "11", Authorization = user.AccessToken, Parameters = AccountDeleteParameters },
                        #endregion

                        #region CreditCard
                        new BatchCallsArguments { Call = CreditCardParameters.BatchUrl(BatchUrlType.Get), ReferenceId = "12", Authorization = user.AccessToken, Parameters = CreditCardParameters },
                        new BatchCallsArguments { Call = CreditCardFindParameters.BatchUrl(), ReferenceId = "13", Authorization = user.AccessToken, Parameters = CreditCardFindParameters },
                        new BatchCallsArguments { Call = CreditCardAuthorizeParameters.BatchUrl(BatchUrlType.Authorize), ReferenceId = "14", Authorization = user.AccessToken, Parameters = CreditCardAuthorizeParameters },
                        new BatchCallsArguments { Call = CreditCardDeleteParameters.BatchUrl(BatchUrlType.Delete), ReferenceId = "15", Authorization = user.AccessToken, Parameters = CreditCardDeleteParameters },
                        #endregion

                        #region preapproval
                        new BatchCallsArguments { Call = PreapprovalParameters.BatchUrl(BatchUrlType.Get), ReferenceId = "16", Authorization = user.AccessToken, Parameters = PreapprovalParameters },
                        new BatchCallsArguments { Call = PreapprovalFindParameters.BatchUrl(), ReferenceId = "17", Authorization = user.AccessToken, Parameters = PreapprovalFindParameters },
                        new BatchCallsArguments { Call = PreapprovalModifyParameters.BatchUrl(), ReferenceId = "18", Authorization = user.AccessToken, Parameters = PreapprovalModifyParameters },
                        new BatchCallsArguments { Call = PreapprovalCancelParameters.BatchUrl(BatchUrlType.Cancel), ReferenceId = "19", Authorization = user.AccessToken, Parameters = PreapprovalCancelParameters },
                        #endregion

                        #region Checkout
                        new BatchCallsArguments { Call = CheckoutParameters.BatchUrl(BatchUrlType.Get), ReferenceId = "20", Authorization = user.AccessToken, Parameters = CheckoutParameters },
                        new BatchCallsArguments { Call = CheckoutFindParameters.BatchUrl(), ReferenceId = "21", Authorization = user.AccessToken, Parameters = CheckoutFindParameters },
                        new BatchCallsArguments { Call = CheckoutModifyParameters.BatchUrl(), ReferenceId = "22", Authorization = user.AccessToken, Parameters = CheckoutModifyParameters },
                        new BatchCallsArguments { Call = CheckoutCancelParameters.BatchUrl(), ReferenceId = "23", Authorization = user.AccessToken, Parameters = CheckoutCancelParameters },
                        new BatchCallsArguments { Call = CheckoutRefundParameters.BatchUrl(), ReferenceId = "24", Authorization = user.AccessToken, Parameters = CheckoutRefundParameters },
                        #endregion

                        #region Subscription Plan
                        new BatchCallsArguments { Call = SubPlanParameters.BatchUrl(), ReferenceId = "25", Authorization = user.AccessToken, Parameters = SubPlanParameters },
                        new BatchCallsArguments { Call = SubPlanFindParameters.BatchUrl(), ReferenceId = "26", Authorization = user.AccessToken, Parameters = SubPlanFindParameters },
                        new BatchCallsArguments { Call = SubPlanModifyParameters.BatchUrl(), ReferenceId = "27", Authorization = user.AccessToken, Parameters = SubPlanModifyParameters },
                        new BatchCallsArguments { Call = SubPlanDeleteParameters.BatchUrl(), ReferenceId = "28", Authorization = user.AccessToken, Parameters = SubPlanDeleteParameters },
                        #endregion

                        #region Subscription
                        new BatchCallsArguments { Call = SubParameters.BatchUrl(), ReferenceId = "29", Authorization = user.AccessToken, Parameters = SubParameters },
                        new BatchCallsArguments { Call = SubFindParameters.BatchUrl(), ReferenceId = "30", Authorization = user.AccessToken, Parameters = SubFindParameters },
                        new BatchCallsArguments { Call = SubModifyParameters.BatchUrl(), ReferenceId = "31", Authorization = user.AccessToken, Parameters = SubModifyParameters },
                        new BatchCallsArguments { Call = SubCancelParameters.BatchUrl(), ReferenceId = "32", Authorization = user.AccessToken, Parameters = SubCancelParameters },
                        #endregion

                        #region Subscription Charge
                        new BatchCallsArguments { Call = SubChargeParameters.BatchUrl(), ReferenceId = "33", Authorization = user.AccessToken, Parameters = SubChargeParameters },
                        new BatchCallsArguments { Call = SubChargeRefundParameters.BatchUrl(), ReferenceId = "34", Authorization = user.AccessToken, Parameters = SubChargeRefundParameters },
                        #endregion

                        #region Withdrawal
                        new BatchCallsArguments { Call = WithdrawalParameters.BatchUrl(), ReferenceId = "35", Authorization = user.AccessToken, Parameters = WithdrawalParameters },
                        new BatchCallsArguments { Call = WithdrawalFindParameters.BatchUrl(), ReferenceId = "36", Authorization = user.AccessToken, Parameters = WithdrawalFindParameters },
                        new BatchCallsArguments { Call = WithdrawalModifyParameters.BatchUrl(), ReferenceId = "37", Authorization = user.AccessToken, Parameters = WithdrawalModifyParameters }
                        #endregion
                    }
                });

                #endregion

            #endregion

            return View(batchCalls);
        }

        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}