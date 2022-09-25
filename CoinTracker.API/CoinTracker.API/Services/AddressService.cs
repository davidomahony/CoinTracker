using CoinTracker.API.Clients;
using CoinTracker.API.Services.Interfaces;
using CoinTracker.Models.Core;

namespace CoinTracker.API.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressInfoClient addressInfoClient;

        public AddressService(IAddressInfoClient addressInfoClient)
        {
            this.addressInfoClient = addressInfoClient ?? throw new ArgumentNullException(nameof(addressInfoClient));
        }

        public async Task<AddressBalance> GetAddressBalanceAsync(string address)
        {
            var addressBalanceInfo = await this.addressInfoClient.GetAddressBalanceAsync(address);

            // Need to populate to get address balance from address info
            var result = new AddressBalance();

            return result;
        }

        public async Task<IEnumerable<AddressTransaction>> GetAddressTransactionAsync(string address)
        {
            var addressTransactionInfo = await this.addressInfoClient.GetAddressBalanceAsync(address);

            // Need to populate to get address transactions from address info
            var result = new List<AddressTransaction>();

            return result;
        }
    }
}
