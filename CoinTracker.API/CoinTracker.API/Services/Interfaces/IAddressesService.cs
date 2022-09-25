namespace CoinTracker.API.Services.Interfaces
{
    public interface IAddressesService
    {
        Task AddAddressAsync(string address);

        void RemoveAddress(string address);

        IEnumerable<string> ListAddresses();
    }
}
