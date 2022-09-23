namespace CoinTracker.API.Services.Interfaces
{
    public interface IAddressesService
    {
        void AddAddress(string address);

        void RemoveAddress(string address);

        IEnumerable<string> ListAddresses();
    }
}
