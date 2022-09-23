using CoinTracker.Models.Core;

namespace CoinTracker.Models.Responses
{
    public class WalletBalanceResponse
    {
        public WalletBalanceResponse(WalletBalance balance)
        {
            this.WalletBalance = balance;
        }

        public WalletBalance WalletBalance { get; private set; }
    }
}
