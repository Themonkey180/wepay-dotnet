using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using WePay.Entities.Rbits;
using WePay.Entities.Structure;

namespace WePay.Infrastructure
{
    public class WePayRbitsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(WepayRbitStructure).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray jArray = JArray.Load(reader);
            if (!jArray.HasValues) return null;

            WepayRbitStructure[] model = JsonConvert.DeserializeObject<WepayRbitStructure[]>(jArray.ToString());
            dynamic fristPass = JsonConvert.DeserializeObject<dynamic>(jArray.ToString());

            for (int i = 0; i < model.Length; i++)
            {
                string type = model[i].Type;
                var properties = fristPass[i].properties.ToString();

                switch (type)
                {
                    case "person":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitPerson>(properties);
                        break;
                    case "email":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitEmail>(properties);
                        break;
                    case "business_name":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitBusinessName>(properties);
                        break;
                    case "address":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitAddress>(properties);
                        break;
                    case "phone":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitPhone>(properties);
                        break;
                    case "tax_id":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitTaxId>(properties);
                        break;
                    case "website_uri":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitWebsiteUri>(properties);
                        break;
                    case "employment":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitEmployment>(properties);
                        break;
                    case "industry_code":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitIndustryCode>(properties);
                        break;
                    case "business_description":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitBusinessDescription>(properties);
                        break;
                    case "risk_score":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitRiskScore>(properties);
                        break;
                    case "comment":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitComment>(properties);
                        break;
                    case "project":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitProject>(properties);
                        break;
                    case "fundraising_event":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitFundraisingEvent>(properties);
                        break;
                    case "fundraising_team":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitFundraisingTeam>(properties);
                        break;
                    case "acquisition_channel":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitAcquisitionChannel>(properties);
                        break;
                    case "partner_service":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitPartnerService>(properties);
                        break;
                    case "member_to_member_message":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitMemberToMemberMessage>(properties);
                        break;
                    case "external_account":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitExternalAccount>(properties);
                        break;
                    case "editorial_review":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitEditorialReview>(properties);
                        break;
                    case "other_web_content":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitOtherWebContent>(properties);
                        break;
                    case "revenue":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitRevenue>(properties);
                        break;
                    case "conversation":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitConversation>(properties);
                        break;
                    case "business_legal":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitBusinessLegal>(properties);
                        break;
                    case "business_report":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitBusinessReport>(properties);
                        break;
                    case "other_document":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitOtherDocument>(properties);
                        break;
                    case "device_info":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitDeviceInfo>(properties);
                        break;
                    case "control_verification":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitControlVerification>(properties);
                        break;
                    case "risk_review":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitRiskReview>(properties);
                        break;
                    case "risk_review_steps":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitRiskReviewSteps>(properties);
                        break;
                    case "transaction_details":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitTransactionDetails>(properties);
                        break;
                    case "fundraising_campaign":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitFundraisingCampaign>(properties);
                        break;
                    case "fundraising_update":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitFundraisingUpdate>(properties);
                        break;
                    case "member_to_member_stats":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitMemberToMemberStats>(properties);
                        break;
                    case "social_media_shares":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitSocialMediaShares>(properties);
                        break;
                    case "fundraiser_beneficiary_relationship":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitFundraiserBeneficiaryRelationship>(properties);
                        break;
                    case "auto_billing":
                        model[i].Properties = JsonConvert.DeserializeObject<RbitAutoBilling>(properties);
                        break;
                }
            }

            return model;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var settings = new Newtonsoft.Json.JsonSerializerSettings();
            settings.StringEscapeHandling = StringEscapeHandling.EscapeNonAscii;
            settings.NullValueHandling = NullValueHandling.Ignore;
            var data = JsonConvert.SerializeObject(value, Formatting.None, settings);

            writer.WriteRawValue(data);
        }
    }
}