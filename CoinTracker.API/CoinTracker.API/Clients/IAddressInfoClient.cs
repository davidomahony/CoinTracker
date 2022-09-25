﻿using CoinTracker.Models.Core;

namespace CoinTracker.API.Clients
{
    public interface IAddressInfoClient
    {
        Task<AddressBalanceInfo> GetAddressBalanceAsync(string address);

        Task<AddressTransactionInfo> GetAddressTransactionsAsync(string address);

        Task<bool> DoesAddressExist(string address);
    }
}
