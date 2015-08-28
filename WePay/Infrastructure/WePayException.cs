using System;
using System.Net;
using WePay.Entities;

namespace WePay.Infrastructure
{
    [Serializable]
    public class WePayException : ApplicationException
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public WePayError WePayError { get; set; }

        public WePayException() 
        { 
        }

        public WePayException(HttpStatusCode httpStatusCode, WePayError wepayError, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
            WePayError = wepayError;
        }
    }
}
