namespace CoinTracker.API.Services.Interfaces
{
    public interface IAddressesService
    {
        Task AddAddress(string address);

        void RemoveAddress(string address);

        IEnumerable<string> ListAddresses();
    }
}
