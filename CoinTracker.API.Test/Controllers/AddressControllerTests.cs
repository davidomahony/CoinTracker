using CoinTracker.API.Controllers;
using CoinTracker.API.Services.Interfaces;
using CoinTracker.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoinTracker.API.Test.Controllers
{
    [TestFixture]
    public class AddressControllerTests
    {
        private Mock<IAddressService> addressService;
        public AddressController addresController;

        [SetUp]
        public void SetUp()
        {
            this.addressService = new Mock<IAddressService>();
            this.addresController = new AddressController(this.addressService.Object);
        }

        [Test]
        public void ValidateConstructor_MissingAddressService()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new AddressController(null));
        }

        [Test]
        public void ValidateConstructor_Valid()
        {
            var controller =  new AddressController(this.addressService.Object);
            Assert.NotNull(controller);
        }

        [Test]
        public async Task ValidateFetchBalance_FetchBalance()
        {
            string address = "Fake Balance";
            int expectedFinalBalance = 100;
            this.addressService.Setup(x => x.GetAddressBalanceAsync(address)).ReturnsAsync(new Models.Core.AddressBalance()
            {
                FinalBalance = expectedFinalBalance
            });

            var result = await this.addresController.FetchBalance(address);
            Assert.NotNull(result);

            var okResult = (OkObjectResult)result;
            Assert.NotNull(okResult);

            var body = okResult.Value as ListAddressBalanceResponse;
            Assert.NotNull(body);
            Assert.AreEqual(address, body.Address);
            Assert.AreEqual(expectedFinalBalance, body.Balance.FinalBalance);

            this.addressService.Verify(x => x.GetAddressBalanceAsync(address), Times.Once);
        }


    }
}
