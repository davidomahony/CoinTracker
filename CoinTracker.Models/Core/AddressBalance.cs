using Newtonsoft.Json;

namespace CoinTracker.Models.Core
{
    public class AddressBalance
    {
        [JsonProperty(PropertyName = "hash160")]
        public string Hash { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "n_tx")]
        public int NumberOfTransactions { get; set; }

        [JsonProperty(PropertyName = "total_received")]
        public long TotalRecieved { get; set; }

        [JsonProperty(PropertyName = "total_sent")]
        public long TotalSent { get; set; }

        [JsonProperty(PropertyName = "final_balance")]
        public long FinalBalance { get; set; }
    }
}
