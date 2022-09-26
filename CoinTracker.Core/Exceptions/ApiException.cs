using System.Net;

namespace CoinTracker.Core.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(HttpStatusCode statusCode, string externalResponseString, string internallyLoggedString)
        : base(internallyLoggedString)
        {
            StatusCode = statusCode;
            ExternalResponseString = externalResponseString;
            InternallyLoggedString = internallyLoggedString;
        }

        public HttpStatusCode StatusCode { get; private set; }

        public string ExternalResponseString { get; private set; }

        public string InternallyLoggedString { get; private set; }
    }
}
