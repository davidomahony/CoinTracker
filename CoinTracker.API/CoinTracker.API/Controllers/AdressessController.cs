using CoinTracker.API.Services.Interfaces;
using CoinTracker.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public IActionResult ListAddresses()
        {
            var result = this.addressesService.ListAddresses();

            var response = new ListAddressesResponse(result);

            return Ok(response);
        }

        [HttpPost("AddAddresses")]
        public IActionResult AddAddresses([Required][FromBody]string address)
        {
            this.addressesService.AddAddressAsync(address);

            return Ok("Added Address");
        }


        [HttpDelete("RemoveAddresses")]
        public IActionResult RemoveAddresses([Required][FromBody] string address)
        {
            this.addressesService.RemoveAddress(address);

            return Ok("Address removed");
        }
    }
}
