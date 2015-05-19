using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WePay.Entities;
using WePay.Entities.Structure;

namespace WePay.Infrastructure
{
        public static class Mapper<T>
        {
            public static T MapFromJson(string json, string parentToken = null)
            {
                var jsonToParse = string.IsNullOrEmpty(parentToken) ? json : JObject.Parse(json).SelectToken(parentToken).ToString();

                return JsonConvert.DeserializeObject<T>(jsonToParse);
            }
        }

        public static class Mapper
        {
            public async static Task<List<WepayBatch>> MapBatchFromJson(string json)
            {
                dynamic frist = JsonConvert.DeserializeObject<dynamic>(json);
                List<WepayBatch> list = new List<WepayBatch>();
                foreach (var a in await Task.WhenAll(frist.calls))
                {
                    var temp = a.response.ToString();
                    if (temp.Contains("error_code"))
                    {
                        WePayError error = JsonConvert.DeserializeObject<WePayError>(temp);
                        error.BatchCall = a.call;
                        error.BatchReferenceId = a.reference_id ?? "";
                        list.Add(error);
                    }
                    else
                    {
                        var referenceId = a.reference_id.ToString() ?? "";
                        var call = a.call.ToString() ?? "";
                        list.Add(WepayType(call, referenceId, temp));
                    }

                }
                return list;
            }

            public static WepayBatch WepayType(string call, string referenceId, string json)
            {
                switch (call)
                {
                    #region oauth2
                    case "/oauth2/token":
                        WepayOauth2Token oauth2Token = JsonConvert.DeserializeObject<WepayOauth2Token>(json);
                        oauth2Token.BatchCall = call;
                        oauth2Token.BatchReferenceId = referenceId ?? "";
                        return oauth2Token;
                    #endregion

                    #region app
                    case "/app":
                        WepayApp appResponse = JsonConvert.DeserializeObject<WepayApp>(json);
                        appResponse.BatchCall = call;
                        appResponse.BatchReferenceId = referenceId ?? "";
                        return appResponse;
                    case "/app/modify":
                        WepayAppModify appModify = JsonConvert.DeserializeObject<WepayAppModify>(json);
                        appModify.BatchCall = call;
                        appModify.BatchReferenceId = referenceId ?? "";
                        return appModify;
                    #endregion

                    #region user
                    case "/user":
                        WePayUser userResponse = JsonConvert.DeserializeObject<WePayUser>(json);
                        userResponse.BatchCall = call;
                        userResponse.BatchReferenceId = referenceId ?? "";
                        return userResponse;
                    case "/user/modify":
                        WePayUser userModify = JsonConvert.DeserializeObject<WePayUser>(json);
                        userModify.BatchCall = call;
                        userModify.BatchReferenceId = referenceId ?? "";
                        return userModify;
                    case "/user/register":
                        WePayUserRegisterd userRegister = JsonConvert.DeserializeObject<WePayUserRegisterd>(json);
                        userRegister.BatchCall = call;
                        userRegister.BatchReferenceId = referenceId ?? "";
                        return userRegister;
                    case "/user/send_confirmation":
                        WePayUserSendConfirmation userSC = JsonConvert.DeserializeObject<WePayUserSendConfirmation>(json);
                        userSC.BatchCall = call;
                        userSC.BatchReferenceId = referenceId ?? "";
                        return userSC;
                    #endregion

                    #region account
                    case "/account":
                    case "/account/create":
                    case "/account/modify":
                        WepayAccount accountResponse = JsonConvert.DeserializeObject<WepayAccount>(json);
                        accountResponse.BatchCall = call;
                        accountResponse.BatchReferenceId = referenceId;
                        return accountResponse;

                    case "/account/find":
                        WepayAccountFind accountFind = new WepayAccountFind
                        {
                            BatchCall = call,
                            BatchReferenceId = referenceId,
                            Accounts = JsonConvert.DeserializeObject<WepayAccount[]>(json)
                        };
                        return accountFind;

                    case "/account/delete":
                        WePayAccountState accountDelete = JsonConvert.DeserializeObject<WePayAccountState>(json);
                        accountDelete.BatchCall = call;
                        accountDelete.BatchReferenceId = referenceId;
                        return accountDelete;

                    case "/account/get_update_uri":
                        WepayAccountUpdatedUri accountUpdatedUri = JsonConvert.DeserializeObject<WepayAccountUpdatedUri>(json);
                        accountUpdatedUri.BatchCall = call;
                        accountUpdatedUri.BatchReferenceId = referenceId;
                        return accountUpdatedUri;

                    case "/account/get_reserve_details":
                        WepayAccountReserveDetails accountReserveDetails = JsonConvert.DeserializeObject<WepayAccountReserveDetails>(json);
                        accountReserveDetails.BatchCall = call;
                        accountReserveDetails.BatchReferenceId = referenceId;
                        return accountReserveDetails;
                    #endregion

                    #region checkout
                    case "/checkout":
                    case "/checkout/create":
                    case "/checkout/modify":
                        WePayCheckout checkoutResponse = JsonConvert.DeserializeObject<WePayCheckout>(json);
                        checkoutResponse.BatchCall = call;
                        checkoutResponse.BatchReferenceId = referenceId;
                        return checkoutResponse;

                    case "/checkout/find":
                        WepayCheckoutFind checkoutFind = new WepayCheckoutFind
                        {
                            BatchCall = call,
                            BatchReferenceId = referenceId,
                            Checkouts = JsonConvert.DeserializeObject<WePayCheckout[]>(json)
                        };
                        return checkoutFind;

                    case "/checkout/cancel":
                    case "/checkout/refund":
                    case "/checkout/capture":
                        WePayCheckoutState checkoutState = JsonConvert.DeserializeObject<WePayCheckoutState>(json);
                        checkoutState.BatchCall = call;
                        checkoutState.BatchReferenceId = referenceId;
                        return checkoutState;
                    #endregion

                    #region preapproval
                    case "/preapproval":
                    case "/preapproval/modify":
                        WePayPreapproval preapprovalResponse = JsonConvert.DeserializeObject<WePayPreapproval>(json);
                        preapprovalResponse.BatchCall = call;
                        preapprovalResponse.BatchReferenceId = referenceId;
                        return preapprovalResponse;

                    case "/preapproval/find":
                        WePayPreapprovalFind preapprovalFind = new WePayPreapprovalFind
                        {
                            BatchCall = call,
                            BatchReferenceId = referenceId,
                            Preapprovals = JsonConvert.DeserializeObject<WePayPreapproval[]>(json)
                        };
                        return preapprovalFind;

                    case "/preapproval/create":
                        WePayPreapprovalCreate preapprovalCreate = JsonConvert.DeserializeObject<WePayPreapprovalCreate>(json);
                        preapprovalCreate.BatchCall = call;
                        preapprovalCreate.BatchReferenceId = referenceId;
                        return preapprovalCreate;

                    case "/preapproval/cancel":
                        WePayPreapprovalState preapprovalState = JsonConvert.DeserializeObject<WePayPreapprovalState>(json);
                        preapprovalState.BatchCall = call;
                        preapprovalState.BatchReferenceId = referenceId;
                        return preapprovalState;
                    #endregion

                    #region withdrawal
                    case "/withdrawal":
                    case "/withdrawal/modify":
                        WePayWithdrawal withdrawalResponse = JsonConvert.DeserializeObject<WePayWithdrawal>(json);
                        withdrawalResponse.BatchCall = call;
                        withdrawalResponse.BatchReferenceId = referenceId;
                        return withdrawalResponse;

                    case "/withdrawal/find":
                        WePayWithdrawalFind withdrawalFind = new WePayWithdrawalFind
                        {
                            BatchCall = call,
                            BatchReferenceId = referenceId,
                            Withdrawals = JsonConvert.DeserializeObject<WePayWithdrawal[]>(json)
                        };
                        return withdrawalFind;

                    case "/withdrawal/create":
                        WePayWithdrawalCreated withdrawalCreate = JsonConvert.DeserializeObject<WePayWithdrawalCreated>(json);
                        withdrawalCreate.BatchCall = call;
                        withdrawalCreate.BatchReferenceId = referenceId;
                        return withdrawalCreate;
                    #endregion

                    #region CreditCard
                    case "/credit_card":
                        WePayCreditCard CreditCardResponse = JsonConvert.DeserializeObject<WePayCreditCard>(json);
                        CreditCardResponse.BatchCall = call;
                        CreditCardResponse.BatchReferenceId = referenceId;
                        return CreditCardResponse;

                    case "/credit_card/find":
                        WePayCreditCardFind CreditCardlFind = new WePayCreditCardFind
                        {
                            BatchCall = call,
                            BatchReferenceId = referenceId,
                            CreditCards = JsonConvert.DeserializeObject<WePayCreditCard[]>(json)
                        };
                        return CreditCardlFind;

                    case "/credit_card/create":
                    case "/credit_card/authorize":
                    case "/credit_card/delete":
                        WePayCreditCardState CreditCardState = JsonConvert.DeserializeObject<WePayCreditCardState>(json);
                        CreditCardState.BatchCall = call;
                        CreditCardState.BatchReferenceId = referenceId;
                        return CreditCardState;
                    #endregion

                    #region SubscriptionPlan
                    case "/subscription_plan":
                    case "/subscription_plan/create":
                    case "/subscription_plan/modify":
                        WePaySubscriptionPlan SubPlanResponse = JsonConvert.DeserializeObject<WePaySubscriptionPlan>(json);
                        SubPlanResponse.BatchCall = call;
                        SubPlanResponse.BatchReferenceId = referenceId;
                        return SubPlanResponse;

                    case "/subscription_plan/find":
                        WePaySubscriptionPlanFind SubPlanFind = new WePaySubscriptionPlanFind
                        {
                            BatchCall = call,
                            BatchReferenceId = referenceId,
                            SubscriptionPlans = JsonConvert.DeserializeObject<WePaySubscriptionPlan[]>(json)
                        };
                        return SubPlanFind;

                    case "/subscription_plan/delete":
                        WePaySubscriptionPlanState SubPlanState = JsonConvert.DeserializeObject<WePaySubscriptionPlanState>(json);
                        SubPlanState.BatchCall = call;
                        SubPlanState.BatchReferenceId = referenceId;
                        return SubPlanState;
                    #endregion

                    #region Subscription
                    case "/subscription":
                    case "/subscription/modify":
                        WePaySubscription SubResponse = JsonConvert.DeserializeObject<WePaySubscription>(json);
                        SubResponse.BatchCall = call;
                        SubResponse.BatchReferenceId = referenceId;
                        return SubResponse;

                    case "/subscription/find":
                        WePaySubscriptionFind SubFind = new WePaySubscriptionFind
                        {
                            BatchCall = call,
                            BatchReferenceId = referenceId,
                            Subscriptions = JsonConvert.DeserializeObject<WePaySubscription[]>(json)
                        };
                        return SubFind;

                    case "/subscription/cancel":
                        WePaySubscriptionPlanState SubState = JsonConvert.DeserializeObject<WePaySubscriptionPlanState>(json);
                        SubState.BatchCall = call;
                        SubState.BatchReferenceId = referenceId;
                        return SubState;

                    case "/subscription/create":
                        WePaySubscriptionCreate Subcreate = JsonConvert.DeserializeObject<WePaySubscriptionCreate>(json);
                        Subcreate.BatchCall = call;
                        Subcreate.BatchReferenceId = referenceId;
                        return Subcreate;
                    #endregion

                    #region SubscriptionCharge
                    case "/subscription_charge":
                        WePaySubscriptionCharge SubChargeResponse = JsonConvert.DeserializeObject<WePaySubscriptionCharge>(json);
                        SubChargeResponse.BatchCall = call;
                        SubChargeResponse.BatchReferenceId = referenceId;
                        return SubChargeResponse;

                    case "/subscription_charge/find":
                        WePaySubscriptionChargeFind SubChargeFind = new WePaySubscriptionChargeFind
                        {
                            BatchCall = call,
                            BatchReferenceId = referenceId,
                            SubscriptionCharges = JsonConvert.DeserializeObject<WePaySubscriptionCharge[]>(json)
                        };
                        return SubChargeFind;

                    case "/subscription_charge/refund":
                        WePaySubscriptionChargeState SubRefund = JsonConvert.DeserializeObject<WePaySubscriptionChargeState>(json);
                        SubRefund.BatchCall = call;
                        SubRefund.BatchReferenceId = referenceId;
                        return SubRefund;

                    #endregion

                    default:
                        WePayError error = JsonConvert.DeserializeObject<WePayError>(json);
                        error.BatchCall = call;
                        error.BatchReferenceId = referenceId;
                        return error;
                }
            }
        }
    }

