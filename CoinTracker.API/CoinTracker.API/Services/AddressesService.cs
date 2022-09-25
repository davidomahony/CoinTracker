using CoinTracker.API.Clients.Interfaces;
using CoinTracker.API.Constants;
using CoinTracker.API.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using System.Web.Http;

namespace CoinTracker.API.Services
{
    public class AddressesService : IAddressesService
    {
        private const string AddressesCacheKey = "Addresses_";
        private readonly IAddressInfoClient addressInfoClient;
        private IList<string> addresses;

        public AddressesService(IMemoryCache cache, IAddressInfoClient addressInfoClient)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }

            this.addressInfoClient = addressInfoClient ?? throw new ArgumentNullException(nameof(addressInfoClient));

            this.PopulateAddresses(cache);
        }

        public async Task AddAddressAsync(string address)
        {
            if (this.addresses.Contains(address))
            {
                throw new HttpResponseException(ClientErrorResponseMessages.ExistingAddressResponse);
            }

            if (!(await ValidateAddressExists(address)))
            {
                throw new HttpResponseException(ClientErrorResponseMessages.InvalidAddressResponse);
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
                throw new HttpResponseException(ClientErrorResponseMessages.NonExistingAddressResponse);
            }

            this.addresses.Remove(address);
        }

        private void PopulateAddresses(IMemoryCache cache)
        {
            var cacheResult = cache.Get(AddressesCacheKey);
            this.addresses = cacheResult as IList<string> ?? new List<string>();
        }

        private Task<bool> ValidateAddressExists(string address)
        {
            return this.addressInfoClient.DoesAddressExist(address);
        }
    }
}
