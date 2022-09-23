namespace CoinTracker.Models.Responses
{
    public class ListAddressesResponse
    {
        public ListAddressesResponse(IEnumerable<string> addresses)
        {
            this.Addresses = addresses;
        }

        public IEnumerable<string> Addresses { get; private set; }
    }
}
