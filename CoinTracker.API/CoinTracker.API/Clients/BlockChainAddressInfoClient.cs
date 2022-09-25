using CoinTracker.API.Clients.Interfaces;
using CoinTracker.Models.Core;

namespace CoinTracker.API.Clients
{
    public class BlockChainAddressInfoClient : IAddressInfoClient
    {
        public Task<bool> DoesAddressExist(string address)
        {
            throw new NotImplementedException();
        }

        public Task<AddressBalanceInfo> GetAddressBalanceAsync(string address)
        {
            throw new NotImplementedException();
        }

        public Task<AddressTransactionInfo> GetAddressTransactionsAsync(string address)
        {
            throw new NotImplementedException();
        }
    }
}
