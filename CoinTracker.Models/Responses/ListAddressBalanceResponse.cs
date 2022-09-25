using CoinTracker.Models.Core;

namespace CoinTracker.Models.Responses
{
    public class ListAddressBalanceResponse
    {
        public ListAddressBalanceResponse(AddressBalance balance)
        {
            this.Balance = balance;
        }

        public AddressBalance Balance { get; private set; }

        public string Address { get; private set; }
    }
}
