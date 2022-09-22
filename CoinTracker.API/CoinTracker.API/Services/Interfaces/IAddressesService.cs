namespace CoinTracker.API.Services.Interfaces
{
    public interface IAddressesService
    {
        Task AddAddress(string address);

        Task RemoveAddress(string address);

        Task<string> ListAddresses();
    }
}
