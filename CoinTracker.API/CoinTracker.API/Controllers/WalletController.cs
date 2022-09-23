using CoinTracker.API.Services.Interfaces;
using CoinTracker.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CoinTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService walletService;

        public WalletController(IWalletService walletService)
        {
            this.walletService = walletService ?? throw new ArgumentException(nameof(walletService));
        }

        [HttpGet("balance")]
        public async Task<IActionResult> GetWalletBalance()
        {
            var result = await this.walletService.GetBalanceAsync();

            var response = new WalletBalanceResponse(result);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetWalletTransactions()
        {
            var result = await this.walletService.GetTransactionsAsync();

            var response = new WalletTransactionsResponse(result);

            return Ok(response);
        }
    }
}
