using CoinTracker.API.Clients;
using CoinTracker.API.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace CoinTracker.API.Services
{
    public class AddressesService : IAddressesService
    {
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
            // first validate address
            // Does it exist in the wallet already
            // Is it a valid address

            if (this.addresses.Contains(address))
            {
                // return response which indicates already exists in wallet
            }

            if (!(await ValidateAddressExists(address)))
            {
                // return response which indicates address is not real maybe 404
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
                // return response which indicates already exists in wallet
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
