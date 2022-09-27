using CoinTracker.API.Services.Interfaces;
using CoinTracker.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CoinTracker.API.Controllers
{
    [ApiController]
    [Route("v1/address/{address}/")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService ?? throw new ArgumentNullException(nameof(addressService));
        }

        [HttpGet("balance")]
        public async Task<IActionResult> FetchBalance([Required] [FromRoute] string address)
        {
            var result = await this.addressService.GetAddressBalanceAsync(address);

            var response = new ListAddressBalanceResponse(result)
            {
                Address = address
            };

            return new OkObjectResult(response);
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> FetchTransactions([Required] [FromRoute] string address)
        {
            var result = await this.addressService.GetAddressTransactionAsync(address);

            var response = new ListAddressTransactionsResponse(result)
            {
                Address = address
            };

            return new OkObjectResult(response);
        }
    }
}
