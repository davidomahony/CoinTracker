using Newtonsoft.Json;

namespace CoinTracker.Models.Core
{
    public class AddressTransactionInfo
    {
        [JsonProperty(PropertyName = "hash160")]
        public string Hash { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "n_tx")]
        public int NumberOfTransactions { get; set; }

        [JsonProperty(PropertyName = "txs")]
        public IEnumerable<TransactionInfo> Transactions { get; set; }
    }

    public class TransactionInfo
    {
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "hash")]
        public string Hash { get; set; }

        [JsonProperty(PropertyName = "time")]
        public long Time { get; set; }

        [JsonProperty(PropertyName = "balance")]
        public long Balance { get; set; }

        [JsonProperty(PropertyName = "fee")]
        public long Fee { get; set; }
    }
}
