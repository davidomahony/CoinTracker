﻿using CoinTracker.Models.Core;

namespace CoinTracker.API.Services.Interfaces
{
    public interface IAddressService
    {
        Task<AddressBalance> GetAddressBalanceAsync(string address);

        Task<AddressTransaction> GetAddressTransactionAsync(string address);
    }
}
