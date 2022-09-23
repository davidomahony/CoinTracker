using CoinTracker.Models.Core;

namespace CoinTracker.Models.Responses
{
    public class ListAddressTransactionsResponse
    {
        public ListAddressTransactionsResponse(IEnumerable<AddressTransaction> transactions)
        {
            this.Transactions = transactions;
        }

        public IEnumerable<AddressTransaction> Transactions { get; set; }

        public string Address { get; set; }
    }
}
