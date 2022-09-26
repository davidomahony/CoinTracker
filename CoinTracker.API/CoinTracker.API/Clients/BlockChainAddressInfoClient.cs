using CoinTracker.API.Clients.Interfaces;
using CoinTracker.Core.Exceptions;
using CoinTracker.Models.Core;

namespace CoinTracker.API.Clients
{
    public class BlockChainAddressInfoClient : IAddressInfoClient
    {
        private readonly HttpClient httpClient;

        public BlockChainAddressInfoClient(IHttpClientFactory httpClientFactory)
        {
            if (httpClientFactory == null)
            {
                throw new ArgumentNullException(nameof(httpClientFactory));
            }

            var client = httpClientFactory.CreateClient("BlockChainAddressInfoClient");
            if (client == null)
            {
                throw new ArgumentNullException("BlockChainAddressInfoClient");
            }
            this.httpClient = client;
        }

        public async Task<bool> DoesAddressExist(string address)
        {
            var response = await this.httpClient.GetAsync($"rawaddr/{address}?offset=0&limit=1");

            if ((int)response.StatusCode < 499)
            {
                throw new ApiException(
                    System.Net.HttpStatusCode.InternalServerError,
                    "Failed to validate address",
                    $"Does Address exist call failed to client {this.httpClient.BaseAddress} for address {address}");
            }

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<AddressBalanceInfo> GetAddressBalanceAsync(string address)
        {
            var response = await this.httpClient.GetAsync($"rawaddr/{address}");

            if ((int)response.StatusCode > 499)
            {
                throw new ApiException(
                    System.Net.HttpStatusCode.InternalServerError,
                    "Failed to get address balance",
                    $"Get address balance call failed to client {this.httpClient.BaseAddress} for address {address}");
            }

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsAsync<AddressBalanceInfo>();

            return content;
        }

        public async Task<AddressTransactionInfo> GetAddressTransactionsAsync(string address)
        {
            var response = await this.httpClient.GetAsync($"rawaddr/{address}");

            if ((int)response.StatusCode > 499)
            {
                throw new ApiException(
                    System.Net.HttpStatusCode.InternalServerError,
                    "Failed to get address transactions",
                    $"Get address transactions call failed to client {this.httpClient.BaseAddress} for address {address}");
            }

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsAsync<AddressTransactionInfo>();

            return content;
        }
    }
}
