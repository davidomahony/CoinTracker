using CoinTracker.API.Clients;
using CoinTracker.API.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using System.Web.Http;

namespace CoinTracker.API.Services
{
    public class AddressesService : IAddressesService
    {
        // I would like to put these known error responses in there own file
        private readonly HttpResponseMessage InvalidAddressResponse = new HttpResponseMessage(HttpStatusCode.NotFound)
        {
            ReasonPhrase = "Address inputted is not a valid address"
        };

        private readonly HttpResponseMessage ExistingAddressResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
        {
            ReasonPhrase = "Address already exist in the wallet"
        };

        private readonly HttpResponseMessage NonExistingAddressResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
        {
            ReasonPhrase = "Address does not exist in wallet"
        };

        private IList<string> addresses;
        private IAddressInfoClient addressInfoClient;

        public AddressesService(IMemoryCache cache, IAddressInfoClient addressInfoClient)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }

            this.addressInfoClient = addressInfoClient ?? throw new ArgumentNullException(nameof(addressInfoClient));

            this.PopulateAddresses(cache);
        }

        public async Task AddAddress(string address)
        {
            if (this.addresses.Contains(address))
            {
                throw new HttpResponseException(ExistingAddressResponse);
            }

            if (!(await ValidateAddressExists(address)))
            {
                throw new HttpResponseException(InvalidAddressResponse);
            }

            this.addresses.Add(address);
        }

        public IEnumerable<string> ListAddresses()
        {
            return this.addresses;
        }

        public void RemoveAddress(string address)
        {
            if (!this.addresses.Contains(address))
            {
                throw new HttpResponseException(NonExistingAddressResponse);
            }

            this.addresses.Remove(address);
        }

        private void PopulateAddresses(IMemoryCache cache)
        {
            this.addresses = new List<string>();
        }

        private Task<bool> ValidateAddressExists(string address)
        {
            return this.addressInfoClient.DoesAddressExist(address);
        }
    }
}
