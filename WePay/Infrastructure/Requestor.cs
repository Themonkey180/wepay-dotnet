using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WePay.Entities;

namespace WePay.Infrastructure
{
    class Requestor
    {
        public static string PostStringBearer(string url, string AccessToken = null, string json = null)
        {
            var wr = GetWebRequest(url, "POST", json, AccessToken, true);

            return ExecuteWebRequest(wr); 
        }

        public  static string PostString(string url, string json = null)
        {
            var wr = GetWebRequest(url, "POST", json);

            return ExecuteWebRequest(wr);
        }

        public static Task<string> PostStringBearerAsync(string url, string AccessToken = null, string json = null)
        {
            var wr = GetWebRequestAsync(url, "POST", json, AccessToken, true).Result;

            return ExecuteWebRequestAsync(wr);
        }

        public static Task<string> PostStringAsync(string url, string json = null)
        {
            var wr = GetWebRequestAsync(url, "POST", json).Result;

            return ExecuteWebRequestAsync(wr);
        }

        internal async static Task<WebRequest> GetWebRequestAsync(string url, string method, string json, string AccessToken = null, bool useBearer = false)
        {
            try
            {
                return await Task.Run(() => GetWebRequest(url, method, json, AccessToken, useBearer)).ConfigureAwait(false);
            }
            catch
            {
                throw;
            }
        }

        internal static WebRequest GetWebRequest(string url, string method, string json, string AccessToken = null, bool useBearer = false)
        {
            AccessToken = string.IsNullOrWhiteSpace(AccessToken) ? WePayConfiguration.GetAccessToken() : AccessToken;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;

            if (useBearer)
                request.Headers.Add("Authorization", GetAuthorizationHeaderValueBearer(AccessToken));

            request.Headers.Add("Api-Version", WePayConfiguration.ApiVersion);

            request.ContentType = "application/json";
            request.UserAgent = "Wepay.net SDK";

            if (json != null)
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
            return request;
        }

        private static string GetAuthorizationHeaderValueBearer(string AccessToken)
        {
            return string.Format("Bearer {0}", AccessToken);
        }

        private async static Task<string> ExecuteWebRequestAsync(WebRequest webRequest)
        {
            try
            {
                return await Task.Run(() => ExecuteWebRequest(webRequest)).ConfigureAwait(false);
            }
            catch
            {
                throw;
            }
        }

        private static string ExecuteWebRequest(WebRequest webRequest)
        {
            try
            {
                using (var response = webRequest.GetResponse())
                {
                    return ReadStream(response.GetResponseStream());
                }
            }
            catch (WebException webException)
            {
                if (webException.Response != null)
                {
                    var statusCode = ((HttpWebResponse)webException.Response).StatusCode;

                    var wePayError = new WePayError();

                    wePayError = WePay.Infrastructure.WepayMapping<WePayError>.MapFromJson(ReadStream(webException.Response.GetResponseStream()));

                    throw new WePayException(statusCode, wePayError, wePayError.ErrorDescription);
                }
                else
                {
                    throw webException;
                }
            }
        }

        private static string ReadStream(Stream stream)
        {
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
