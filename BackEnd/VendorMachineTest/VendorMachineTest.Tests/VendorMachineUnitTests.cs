using VendorMachineTest.Domain.ViewModels;
using VendorMachineTest.Tests.Infrastructure;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Xunit;

namespace VendorMachineTest.Tests
{
    public class VendorMachineUnitTests : InMemoryTestBase
    {
        public VendorMachineUnitTests()
        {

        }

        [Fact]
        public async void GivenGetProducts_WhenCallAPI_ThenShouldRetrieveProducts()
        {
            //assert
            var client = testServer.CreateClient();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            //act
            var response = await client.GetAsync($"signalr/webapi/v1/Product/GetProducts");
            var products = JsonSerializer.Deserialize<IEnumerable<ProductViewModel>>(await response.Content.ReadAsStringAsync(), options);

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(products);

            client.Dispose();
        }

        [Fact]
        public async void GivenGetProduct_WhenCallAPIUsingAnId_ThenShouldRetrieveResult()
        {
            //assert
            var client = testServer.CreateClient();
            var productId = 2;
            var nameShouldBe = "IPad Pro";
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            //act
            var response = await client.GetAsync($"signalr/webapi/v1/Product/GetProductById/{productId}");
            var product = JsonSerializer.Deserialize<ProductViewModel>(await response.Content.ReadAsStringAsync(), options);

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(nameShouldBe, product.Name);

            client.Dispose();
        }
    }
}
