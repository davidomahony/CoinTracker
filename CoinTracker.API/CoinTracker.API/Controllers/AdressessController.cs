using CoinTracker.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoinTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdressessController : ControllerBase
    {
        private readonly IAddressesService addressesService;

        public AdressessController(IAddressesService addressesService)
        {
            this.addressesService = addressesService ?? throw new ArgumentNullException(nameof(addressesService));
        }

        [HttpGet("ListAddresses")]
        public IEnumerable<string> ListAddresses()
        {
            var result = this.addressesService.ListAddresses();

            return new OkObjectResult();
        }
    }
}
