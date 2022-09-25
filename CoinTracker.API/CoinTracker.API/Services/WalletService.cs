using CoinTracker.API.Services.Interfaces;
using CoinTracker.Models.Core;

namespace CoinTracker.API.Services
{
    public class WalletService : IWalletService
    {
        public Task<WalletBalance> GetBalanceAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AddressTransaction>> GetTransactionsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
