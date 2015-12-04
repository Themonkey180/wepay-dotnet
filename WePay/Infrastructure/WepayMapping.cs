using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WePay.Entities;
using WePay.Entities.Structure;
using WePay.Entities.Rbits;

namespace WePay.Infrastructure
{
        public static class WepayMapping<T>
        {
            public static T MapFromJson(string json, string parentToken = null)
            {
                var jsonToParse = string.IsNullOrEmpty(parentToken) ? json : JObject.Parse(json).SelectToken(parentToken).ToString();

                return JsonConvert.DeserializeObject<T>(jsonToParse);
            }

            public static WepayRbit MapRbitsFromJson(string json, string parentToken = null)
            {
                var jsonToParse = string.IsNullOrEmpty(parentToken) ? json : JObject.Parse(json).SelectToken(parentToken).ToString();
                WepayRbit model  = JsonConvert.DeserializeObject<WepayRbit>(jsonToParse);

                string type = model.Type;

                dynamic fristPass = JsonConvert.DeserializeObject<dynamic>(json);
                var properties = fristPass.properties.ToString();

                switch (type)
                {
                    case "person":
                        model.Properties = JsonConvert.DeserializeObject<RbitPerson>(properties);
                        break;
                    case "email":
                        model.Properties = JsonConvert.DeserializeObject<RbitEmail>(properties);
                        break;
                    case "business_name":
                        model.Properties = JsonConvert.DeserializeObject<RbitBusinessName>(properties);                       
                        break;
                    case "address":
                        model.Properties = JsonConvert.DeserializeObject<RbitAddress>(properties);                       
                        break;
                    case "phone":
                        model.Properties = JsonConvert.DeserializeObject<RbitPhone>(properties);                       
                        break;
                    case "tax_id":
                        model.Properties = JsonConvert.DeserializeObject<RbitTaxId>(properties);                       
                        break;
                    case "website_uri":
                        model.Properties = JsonConvert.DeserializeObject<RbitWebsiteUri>(properties);                       
                        break;
                    case "employment":
                        model.Properties = JsonConvert.DeserializeObject<RbitEmployment>(properties);                       
                        break;
                    case "industry_code":
                        model.Properties = JsonConvert.DeserializeObject<RbitIndustryCode>(properties);                      
                        break;
                    case "business_description":
                        model.Properties = JsonConvert.DeserializeObject<RbitBusinessDescription>(properties);                        
                        break;
                    case "risk_score":
                        model.Properties = JsonConvert.DeserializeObject<RbitRiskScore>(properties);                        
                        break;
                    case "comment":
                        model.Properties = JsonConvert.DeserializeObject<RbitComment>(properties);                        
                        break;
                    case "project":
                        model.Properties = JsonConvert.DeserializeObject<RbitProject>(properties);                       
                        break;
                    case "fundraising_event":
                        model.Properties = JsonConvert.DeserializeObject<RbitFundraisingEvent>(properties);                        
                        break;
                    case "fundraising_team":
                        model.Properties = JsonConvert.DeserializeObject<RbitFundraisingTeam>(properties);                       
                        break;
                    case "acquisition_channel":
                        model.Properties = JsonConvert.DeserializeObject<RbitAcquisitionChannel>(properties);                       
                        break;
                    case "partner_service":
                        model.Properties = JsonConvert.DeserializeObject<RbitPartnerService>(properties);                       
                        break;
                    case "member_to_member_message":
                        model.Properties = JsonConvert.DeserializeObject<RbitMemberToMemberMessage>(properties);                       
                        break;
                    case "external_account":
                        model.Properties = JsonConvert.DeserializeObject<RbitExternalAccount>(properties);                       
                        break;
                    case "editorial_review":
                        model.Properties = JsonConvert.DeserializeObject<RbitEditorialReview>(properties);                       
                        break;
                    case "other_web_content":
                        model.Properties = JsonConvert.DeserializeObject<RbitOtherWebContent>(properties);                      
                        break;
                    case "revenue":
                        model.Properties = JsonConvert.DeserializeObject<RbitRevenue>(properties);                        
                        break;
                    case "conversation":
                        model.Properties = JsonConvert.DeserializeObject<RbitConversation>(properties);                      
                        break;
                    case "business_legal":
                        model.Properties = JsonConvert.DeserializeObject<RbitBusinessLegal>(properties);                       
                        break;
                    case "business_report":
                        model.Properties = JsonConvert.DeserializeObject<RbitBusinessReport>(properties);                       
                        break;
                    case "other_document":
                        model.Properties = JsonConvert.DeserializeObject<RbitOtherDocument>(properties);                      
                        break;
                    case "device_info":
                        model.Properties = JsonConvert.DeserializeObject<RbitDeviceInfo>(properties);                      
                        break;
                    case "control_verification":
                        model.Properties = JsonConvert.DeserializeObject<RbitControlVerification>(properties);                      
                        break;
                    case "risk_review":
                        model.Properties = JsonConvert.DeserializeObject<RbitRiskReview>(properties);                      
                        break;
                    case "risk_review_steps":
                        model.Properties = JsonConvert.DeserializeObject<RbitRiskReviewSteps>(properties);                      
                        break;
                    case "transaction_details":
                        model.Properties = JsonConvert.DeserializeObject<RbitTransactionDetails>(properties);                      
                        break;
                    case "fundraising_campaign":
                        model.Properties = JsonConvert.DeserializeObject<RbitFundraisingCampaign>(properties);                      
                        break;
                    case "fundraising_update":
                        model.Properties = JsonConvert.DeserializeObject<RbitFundraisingUpdate>(properties);                      
                        break;
                    case "member_to_member_stats":
                        model.Properties = JsonConvert.DeserializeObject<RbitMemberToMemberStats>(properties);                      
                        break;
                    case "social_media_shares":
                        model.Properties = JsonConvert.DeserializeObject<RbitSocialMediaShares>(properties);                      
                        break;
                    case "fundraiser_beneficiary_relationship":
                        model.Properties = JsonConvert.DeserializeObject<RbitFundraiserBeneficiaryRelationship>(properties);                      
                        break;
                    case "auto_billing":
                        model.Properties = JsonConvert.DeserializeObject<RbitAutoBilling>(properties);                     
                        break;
                }

                return model;
            }

        }

        public static class WepayMapping
        {

            public async static Task<List<WepayBatch>> MapBatchFromJson(string json)
            {
                //Sets up the json to be in a list.
                dynamic fristPass = JsonConvert.DeserializeObject<dynamic>(json);
                List<WepayBatch> list = new List<WepayBatch>();

                //This makes a async call that is a Parallel foreach loop that adds the batch response to the list.
                var tasks = await Task.Run(() => Parallel.ForEach((IEnumerable<dynamic>)fristPass.calls, call => list.Add(MapBatchInnerLoop(call)))).ConfigureAwait(false);

                return list;
            }

            public static WepayBatch MapBatchInnerLoop(dynamic JsonCall)
            {
                var temp = JsonCall.response.ToString();
                if (temp.Contains("error_code"))
                {
                    WePayError error = JsonConvert.DeserializeObject<WePayError>(temp);
                    error.BatchCall = JsonCall.call;
                    error.BatchReferenceId = JsonCall.reference_id ?? "";
                    return error;
                }
                else
                {
                    var referenceId = JsonCall.reference_id.ToString() ?? "";
                    var call = JsonCall.call.ToString() ?? "";
                    return WepayType(call, referenceId, temp);
                }
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

