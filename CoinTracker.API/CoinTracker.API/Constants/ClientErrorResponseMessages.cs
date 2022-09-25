using System.Net;

namespace CoinTracker.API.Constants
{
    public class ClientErrorResponseMessages
    {
        public static readonly HttpResponseMessage InvalidAddressResponse = new HttpResponseMessage(HttpStatusCode.NotFound)
        {
            ReasonPhrase = "Address inputted is not a valid address"
        };

        public static readonly HttpResponseMessage ExistingAddressResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
        {
            ReasonPhrase = "Address already exist in the wallet"
        };

        public static readonly HttpResponseMessage NonExistingAddressResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
        {
            ReasonPhrase = "Address does not exist in wallet"
        };
    }
}
