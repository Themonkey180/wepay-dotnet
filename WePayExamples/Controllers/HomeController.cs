﻿using System;
using System.Web.Mvc;
using WePay;
using WePay.Infrastructure;
using WePay.Entities;
using WePay.Entities.Structure;
using WePay.Account;
using WePay.App;
using WePay.Batch;
using WePay.Checkout;
using WePay.CreditCard;
using WePay.Preapproval;
using WePay.Subscription;
using WePay.SubscriptionCharge;
using WePay.SubscriptionPlan;
using WePay.User;
using WePay.Withdrawal;

namespace Controllers
{
    [RouteArea("Home")]
    [RoutePrefix("Home")]
    [Route("{action=index}")]
    public class HomeController : Controller
    {
        [Route("~/")]
        public ActionResult Index()
        {
            ViewBag.accessToken = WePayConfiguration.GetAccessToken();
            ViewBag.clientId = WePayConfiguration.GetClientId();
            ViewBag.clientSecret = WePayConfiguration.GetClientSecret();
            ViewBag.accountId = WePayConfiguration.GetAccountId();
            return View();
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
            var IPAddress = Request.UserHostAddress;

           WepayAddress Address1 = new WepayAddress { Address1 = "605 Seward Ave NW", City="Grand Rapids", State="MI", Zip="49504", Country="US" };

            #endregion

            #region SetUp

                #region User

                var wePayUserService = new WePay.WePayUserService(null, clientId, clientSecret);

                var ParametersRegister = new UserRegisterArguments { 
                    ClientId = clientId, 
                    ClientSecret = clientSecret, 
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    OriginalIp = IPAddress,
                    OriginalDevice = userAgent,
                    TOSAcceptanceTime = DateTime.Now
                };
                WePayUserRegisterd user = null;

                try
                {
                    user = wePayUserService.Register(ParametersRegister);
                }
                catch (WePayException ex)
                {
                    return View("Error", ex);
                }
                #endregion

                #region Accounts

                var wePayAccountService = new WePay.WePayAccountrService(user.AccessToken);
                WepayAccount account = null;
                try
                {
                    account = wePayAccountService.Create(new AccountCreateArgument
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
                }
                catch (WePayException ex)
                {
                    return View("Error", ex);
                }

            WepayAccount accountDelete = null;
            try
            {
                accountDelete = wePayAccountService.Create(new AccountCreateArgument { Name = "SDK Test delete", Description = "An account that is a test made one to delete." });
            }
            catch (WePayException ex)
            {
                return View("Error", ex);
            }
                #endregion

                #region CreditCard
            WePayCreditCardState CreditCard = null;
            WePayCreditCardState CreditCardDelete = null;
            WePayCreditCardState CreditCardAuthorize = null;

                var wePayCreditCardService = new WePay.WePayCreditCardService(user.AccessToken);
                try
                {
                    CreditCard = wePayCreditCardService.Create(new CreditCardCreateArguments
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
                }
                catch (WePayException ex)
                {
                    return View("Error", ex);
                }

                 try
                 {
                     CreditCardDelete = wePayCreditCardService.Create(new CreditCardCreateArguments
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
                 }
                 catch (WePayException ex)
                 {
                     return View("Error", ex);
                 }

                 try
                 {
                     CreditCardAuthorize = wePayCreditCardService.Create(new CreditCardCreateArguments
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
                 }
                 catch (WePayException ex)
                 {
                     return View("Error", ex);
                 }
                #endregion

                #region Preapproval

                 WePayPreapprovalCreate Preapproval = null;
                 WePayPreapprovalCreate PreapprovalCancel = null;

                var wePayPreapprovalService = new WePay.WePayPreapprovalService(user.AccessToken);

                try
                {
                    Preapproval = wePayPreapprovalService.Create(new PreapprovalCreateArguments
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
                }
                catch (WePayException ex)
                {
                    return View("Error", ex);
                }

                try
                {
                    PreapprovalCancel = wePayPreapprovalService.Create(new PreapprovalCreateArguments
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
                }
                catch (WePayException ex)
                {
                    return View("Error", ex);
                }
                #endregion

                #region Checkout

                WePayCheckout checkout = null;
                WePayCheckout checkoutCancel = null;
                WePayCheckout checkoutRefund = null;

                var wePayCheckoutService = new WePay.WePayCheckoutService(user.AccessToken);

                try
                {
                    checkout = wePayCheckoutService.Create(new CheckoutCreateArguments
                    {
                        AccountId = account.AccountId,
                        ShortDescription = "Test a checkout",
                        Type = "personal",
                        Amount = (decimal)100.75,
                        Currency = "USD",
                        Fee = new WepayFee
                        {
                            AppFee = (decimal)3.02,
                            FeePayer = "payee"
                        },
                        EmailMessage = new WepayEmailMessage
                        {
                            ToPayee = "You have just got money.",
                            ToPayer = "Thank you for the money.",
                        },
                        PaymentMethod = new WepayPaymentMethod
                        {
                            Type = "credit_card",
                            CreditCard = new WepayCreditCardInfo
                            {
                                Id = CreditCard.CreditCardId
                            }
                        }
                    });
                }
                catch (WePayException ex)
                {
                    return View("Error", ex);
                }

                try
                {
                    checkoutCancel = wePayCheckoutService.Create(new CheckoutCreateArguments
                    {
                        AccountId = account.AccountId,
                        ShortDescription = "Test a checkout",
                        Type = "personal",
                        Amount = (decimal)100.75,
                        Currency = "USD",
                        Fee = new WepayFee
                        {
                            AppFee = (decimal)3.02,
                            FeePayer = "payee"
                        },
                        EmailMessage = new WepayEmailMessage
                        {
                            ToPayee = "You have just got money.",
                            ToPayer = "Thank you for the money.",
                        },
                        PaymentMethod = new WepayPaymentMethod
                        {
                            Type = "credit_card",
                            CreditCard = new WepayCreditCardInfo
                            {
                                Id = CreditCard.CreditCardId
                            }
                        }
                    });
                }
                catch (WePayException ex)
                {
                    return View("Error", ex);
                }

                try
                {
                    checkoutRefund = wePayCheckoutService.Create(new CheckoutCreateArguments
                    {
                        AccountId = account.AccountId,
                        ShortDescription = "Test a checkout",
                        Type = "personal",
                        Amount = (decimal)100.75,
                        Currency = "USD",
                        Fee = new WepayFee
                        {
                            AppFee = (decimal)3.02,
                            FeePayer = "payee"
                        },
                        EmailMessage = new WepayEmailMessage
                        {
                            ToPayee = "You have just got money.",
                            ToPayer = "Thank you for the money.",
                        },
                        PaymentMethod = new WepayPaymentMethod
                        {
                            Type = "credit_card",
                            CreditCard = new WepayCreditCardInfo
                            {
                                Id = CreditCard.CreditCardId
                            }
                        }
                    });
                }
                catch (WePayException ex)
                {
                    return View("Error", ex);
                }
                #endregion

                #region Subscription Plan

                WePaySubscriptionPlan SubsPlan = null;
                WePaySubscriptionPlan SubsPlanDelete = null;

                var wePaySubscriptionPlanService = new WePay.WePaySubscriptionPlanService(user.AccessToken);

                try
                {
                    SubsPlan = wePaySubscriptionPlanService.Create(new SubscriptionPlanCreateArguments
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
                }
                catch (WePayException ex)
                {
                    return View("Error", ex);
                }

                try
                {
                    SubsPlanDelete = wePaySubscriptionPlanService.Create(new SubscriptionPlanCreateArguments
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
                }
                catch (WePayException ex)
                {
                    return View("Error", ex);
                }

                #endregion

                #region Subscription

                WePaySubscriptionCreate Subs = null;
                WePaySubscriptionCreate SubsCancel = null;

                var wePaySubscriptionService = new WePay.WePaySubscriptionService(user.AccessToken);

                try
                {
                    Subs = wePaySubscriptionService.Create(new SubscriptionCreateArguments
                    {
                        SubscriptionPlanId = SubsPlan.SubscriptionPlanId,
                        PaymentMethodId = CreditCard.CreditCardId,
                        PaymentMethodType = "credit_card"
                    });
                }
                catch (WePayException ex)
                {
                    return View("Error", ex);
                }

                try
                {
                    SubsCancel = wePaySubscriptionService.Create(new SubscriptionCreateArguments
                    {
                        SubscriptionPlanId = SubsPlanDelete.SubscriptionPlanId,
                        PaymentMethodId = CreditCard.CreditCardId,
                        PaymentMethodType = "credit_card"

                    });
                }
                catch (WePayException ex)
                {
                    return View("Error", ex);
                }

                #endregion

                #region Subscription Charge

                WePaySubscriptionCharge[] SubsCharge = null;
                var wePaySubscriptionChargeService = new WePay.WePaySubscriptionChargeService(user.AccessToken);
                try
                {
                    SubsCharge = wePaySubscriptionChargeService.Find(new SubscriptionChargeFindArguments
                    {
                        SubscriptionId = Subs.SubscriptionId
                    });
                }
                catch (WePayException ex)
                {
                    return View("Error", ex);
                }

                #endregion

            #endregion

            #region Batch

                WePayBatchService wePayBatchService = new WePay.WePayBatchService(user.AccessToken, clientId, clientSecret);

                #region BatchArguments

                    #region User
                    var UserSendConfirmation = new UserSendConfirmationArguments { EmailMessage = "Test From Wepay SDK. Made by Pay it Square team." };
                    var UserModify = new UserModifyArguments { CallbackUri = callbackUri };
                    #endregion

                    #region App
                    var AppParameters = new AppArguments { ClientId = clientId, ClientSecret = clientSecret };
                    var AppsModify = new AppModifyArguments { ClientId = clientId, ClientSecret = clientSecret};
                    #endregion

                    #region Account
                    var AccountParameters = new AccountArguments { AccountId = account.AccountId };
                    var AccountFindParameters = new AccountFindArguments { SortOrder = "ASC" };
                    var AccountModifyParameters = new AccountModifyArguments { AccountId = account.AccountId, Description = "SDK test modify" };
                    var AccountGetReserveDetailsParameters = new AccountGetReserveDetailsArguments { AccountId = account.AccountId };
                    var AccountUpdateUriParameters = new AccountGetUpdateUriArguments { AccountId = account.AccountId };
                    var AccountDeleteParameters = new AccountDeleteArguments { AccountId = accountDelete.AccountId, Reason = "Test for delete" };
                    #endregion

                    #region CreditCard
                    var CreditCardParameters = new CreditCardArguments { ClientId = clientId, ClientSecret = clientSecret, CreditCardId = CreditCard.CreditCardId };
                    var CreditCardFindParameters = new CreditCardFindArguments { ClientId = clientId, ClientSecret = clientSecret };
                    var CreditCardAuthorizeParameters = new CreditCardArguments { ClientId = clientId, ClientSecret = clientSecret, CreditCardId = CreditCardAuthorize.CreditCardId };
                    var CreditCardDeleteParameters = new CreditCardArguments { ClientId = clientId, ClientSecret = clientSecret, CreditCardId = CreditCardDelete.CreditCardId };
                    #endregion

                    #region preapproval
                    var PreapprovalParameters = new PreapprovalArguments { PreapprovalId = Preapproval.PreapprovalId };
                    var PreapprovalFindParameters = new PreapprovalFindArguments { AccountId = account.AccountId };
                    var PreapprovalModifyParameters = new PreapprovalModifyArguments { PreapprovalId = Preapproval.PreapprovalId };
                    var PreapprovalCancelParameters = new PreapprovalArguments { PreapprovalId = PreapprovalCancel.PreapprovalId };
                    #endregion

                    #region Checkout
                    var CheckoutParameters = new CheckoutArguments { CheckoutId = checkout.CheckoutId ?? 0 };
                    var CheckoutFindParameters = new CheckoutFindArguments { AccountId = account.AccountId };
                    var CheckoutModifyParameters = new CheckoutModifyArguments { CheckoutId = checkout.CheckoutId };
                    var CheckoutCancelParameters = new CheckoutCancelArguments { CheckoutId = checkoutCancel.CheckoutId, CancelReason = "To test the sdk" };
                    var CheckoutRefundParameters = new CheckoutRefundArguments { CheckoutId = checkoutRefund.CheckoutId };
                    #endregion

                    #region Subscription Plan
                    var SubPlanParameters = new SubscriptionPlanArguments { SubscriptionPlanId = SubsPlan.SubscriptionPlanId };
                    var SubPlanFindParameters = new SubscriptionPlanFindArguments { AccountId = account.AccountId };
                    var SubPlanModifyParameters = new SubscriptionPlanModifyeArguments { SubscriptionPlanId = SubsPlan.SubscriptionPlanId };
                    var SubPlanDeleteParameters = new SubscriptionPlanDeleteArguments { SubscriptionPlanId = SubsPlanDelete.SubscriptionPlanId, reason = "Test the delete." };
                    #endregion

                    #region Subscription
                    var SubParameters = new SubscriptionArguments { SubscriptionId = Subs.SubscriptionId };
                    var SubFindParameters = new SubscriptionFindArguments { SubscriptionPlanId = SubsPlan.SubscriptionPlanId };
                    var SubModifyParameters = new SubscriptionModifyArguments { SubscriptionId = Subs.SubscriptionId };
                    var SubCancelParameters = new SubscriptionCancelArguments { SubscriptionId = SubsCancel.SubscriptionId, Reason = "Testing the Cancel" };
                    #endregion

                    #region Subscription Charge
                    var SubChargeParameters = new SubscriptionChargeArguments { subscriptionChargeId = SubsCharge[0].SubscriptionChargeId };
                    var SubChargeRefundParameters = new SubscriptionChargeRefundArguments { SubscriptionChargeId = SubsCharge[0].SubscriptionChargeId, Reason = "Test the Refund" };
                    #endregion

                    #region Withdrawal
                    var WithdrawalFindParameters = new WithdrawalFindArguments { AccountId = account.AccountId };
                    #endregion

                #endregion

                #region BatchCalls
                    try
                    {
                        var batchCalls = wePayBatchService.Create(new BatchArguments
                        {
                            Calls = new BatchCallsArguments[35] { 

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
                        new BatchCallsArguments { Call = WithdrawalFindParameters.BatchUrl(), ReferenceId = "36", Authorization = user.AccessToken, Parameters = WithdrawalFindParameters },
                        #endregion
                    }
                        });

                        return View(batchCalls);
                    }
                    catch (WePayException ex)
                    {
                        return View("Error", ex);
                    }
                #endregion

            #endregion

        }

    }
}