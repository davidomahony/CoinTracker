using CoinTracker.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTracker.Models.Responses
{
    public class WalletTransactionsResponse
    {
        public WalletTransactionsResponse(IEnumerable<AddressTransaction> transactions)
        {
            this.Transactions = transactions;
        }

        public IEnumerable<AddressTransaction> Transactions { get; set; }
    }
}
