using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinTracker.API.Clients;
using CoinTracker.API.Clients.Interfaces;
using Moq;
using Moq.Protected;

namespace CoinTracker.API.Test.Clients
{
    public class BlockChainAddressInfoClientTests
    {
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
        public async Task BlockChainAddressInfoClientTests_ValidateDoesAddressExist_WithValidAddress()
        {
            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected().Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()).ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                });
            httpClientFactory.Setup(x => x.CreateClient("BlockChainAddressInfoClient")).Returns(new HttpClient(mockHandler.Object)
            {
                BaseAddress = new Uri("https://blockchain.info")
            });

            IAddressInfoClient client = new BlockChainAddressInfoClient(this.httpClientFactory.Object);

            var result = await client.DoesAddressExist(" I am a real address");
            Assert.IsTrue(result);
        }

        [Test]
        public async Task BlockChainAddressInfoClientTests_ValidateDoesAddressExist_WithInValidAddress()
        {
            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected().Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()).ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                });
            httpClientFactory.Setup(x => x.CreateClient("BlockChainAddressInfoClient")).Returns(new HttpClient(mockHandler.Object)
            {
                BaseAddress = new Uri("https://blockchain.info")
            });

            IAddressInfoClient client = new BlockChainAddressInfoClient(this.httpClientFactory.Object);

            var result = await client.DoesAddressExist(" I am a fake address");
            Assert.IsFalse(result);
        }

        [Test]
        [Ignore("Not a unit test")]
        public async Task TestBasicExample_JustToValidate_DoesAddressExist()
        {
            httpClientFactory.Setup(x => x.CreateClient("BlockChainAddressInfoClient")).Returns(
                new HttpClient()
                {
                    BaseAddress = new Uri("https://blockchain.info")
                });

            IAddressInfoClient client = new BlockChainAddressInfoClient(this.httpClientFactory.Object);

            var result = await client.DoesAddressExist("1AJbsFZ64EpEfS5UAjAfcUG8pH8Jn3rn1F");
            Assert.IsTrue(result);

            var falseResult = await client.DoesAddressExist("A Fake Address");
            Assert.IsFalse(falseResult);
        }

        [Test]
        [Ignore("Not a unit test")]
        public async Task TestBasicExample_JustToValidate_GetBalance()
        {
            httpClientFactory.Setup(x => x.CreateClient("BlockChainAddressInfoClient")).Returns(
                new HttpClient()
                {
                    BaseAddress = new Uri("https://blockchain.info")
                });

            IAddressInfoClient client = new BlockChainAddressInfoClient(this.httpClientFactory.Object);

            var result = await client.GetAddressBalanceAsync("1AJbsFZ64EpEfS5UAjAfcUG8pH8Jn3rn1F");
            Assert.NotNull(result);
        }

        [Test]
        [Ignore("Not a unit test")]
        public async Task TestBasicExample_JustToValidate_GetTransactions()
        {
            httpClientFactory.Setup(x => x.CreateClient("BlockChainAddressInfoClient")).Returns(
                new HttpClient()
                {
                    BaseAddress = new Uri("https://blockchain.info")
                });

            IAddressInfoClient client = new BlockChainAddressInfoClient(this.httpClientFactory.Object);

            var result = await client.GetAddressTransactionsAsync("1AJbsFZ64EpEfS5UAjAfcUG8pH8Jn3rn1F");
            Assert.NotNull(result);
        }
    }
}
