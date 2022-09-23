using CoinTracker.Models.Core;

namespace CoinTracker.API.Services.Interfaces
{
    public interface IWalletService
    {
        Task<IEnumerable<AddressTransaction>> GetTransactionsAsync();

        Task<WalletBalance> GetBalanceAsync();
    }
}
