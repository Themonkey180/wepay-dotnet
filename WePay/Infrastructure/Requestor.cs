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

        public static string PostString(string url, string json = null)
        {
            var wr = GetWebRequest(url, "POST", json);

            return ExecuteWebRequest(wr);
        }

        internal static WebRequest GetWebRequest(string url, string method, string json, string AccessToken = null, bool useBearer = false)
        {
            AccessToken = AccessToken ?? WePayConfiguration.GetAccessToken();

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

                    wePayError = WePay.Infrastructure.Mapper<WePayError>.MapFromJson(ReadStream(webException.Response.GetResponseStream()));

                    throw new WePayException(statusCode, wePayError, wePayError.ErrorDescription);
                }

                throw;
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
