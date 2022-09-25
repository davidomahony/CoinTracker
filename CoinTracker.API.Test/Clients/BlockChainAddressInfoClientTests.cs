using CoinTracker.API.Clients;
using CoinTracker.API.Clients.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTracker.API.Test.Clients
{
    public class BlockChainAddressInfoClientTests
    {
        public IAddressInfoClient client;
        public Mock<IHttpClientFactory> httpClientFactory;

        [SetUp]
        public void SetUp()
        {
            httpClientFactory = new Mock<IHttpClientFactory>();
        }

        [Test]
        public void BlockChainAddressInfoClientTests_Constructor_NullFactory()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new BlockChainAddressInfoClient(null));
        }

        [Test]
        public void BlockChainAddressInfoClientTests_Constructor_MissingClient()
        {
            httpClientFactory.Setup(x => x.CreateClient("BlockChainAddressInfoClient")).Returns((HttpClient)null);

            Assert.Throws(typeof(ArgumentNullException), () => new BlockChainAddressInfoClient(this.httpClientFactory.Object));
        }

        [Test]
        public async Task TestBasicExample_JustToValidate()
        {
            httpClientFactory.Setup(x => x.CreateClient("BlockChainAddressInfoClient")).Returns(
                new HttpClient()
                {
                    BaseAddress = new Uri("https://blockchain.info")
                });

            var client = new BlockChainAddressInfoClient(this.httpClientFactory.Object);

            var result = await client.GetAddressBalanceAsync("1AJbsFZ64EpEfS5UAjAfcUG8pH8Jn3rn1F");
            Assert.NotNull(result);
        }

    }
}
