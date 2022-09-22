using CoinTracker.Models.Core;

namespace CoinTracker.API.Services.Interfaces
{
    public interface IWalletService
    {
        Task<IEnumerable<AddressTransaction>> GetTranssactionsAsync();

        Task<IEnumerable<AddressBalance>> GetBalanceAsync();
    }
}
