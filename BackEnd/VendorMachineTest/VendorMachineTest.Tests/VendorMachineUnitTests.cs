using VendorMachineTest.Domain.ViewModels;
using VendorMachineTest.Tests.Infrastructure;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Xunit;
using System.Net.Http;
using System.Text;
using VendorMachineTest.Domain;

namespace VendorMachineTest.Tests
{
    public class VendorMachineUnitTests : InMemoryTestBase
    {
        private const string _urlController = "vendorMachine/webapi/v1/Machine/";
        public VendorMachineUnitTests()
        {

        }

        [Fact]
        public async void Given_GetMachineById_When_Call_API_Then_Should_Return_Result()
        {
            //arrange
            var client = testServer.CreateClient();
            var urlEndPoint = "GetMachineById";
            var machineId = 1;
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            //act
            var response = await client.GetAsync($"{_urlController}{urlEndPoint}/{machineId}");
            var machine = JsonSerializer.Deserialize<MachineViewModel>(await response.Content.ReadAsStringAsync(), options);

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(machine);
            Assert.Equal(machineId, machine.Id);
            client.Dispose();
        }

        [Fact]
        public async void Given_GetSlotsMachineById_When_Call_API_Then_Should_Return_Result()
        {
            //arrange
            var client = testServer.CreateClient();
            var urlEndPoint = "GetSlotsMachineById";
            var machineId = 1;
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            //act
            var response = await client.GetAsync($"{_urlController}{urlEndPoint}/{machineId}");
            var machineSlots = JsonSerializer.Deserialize<List<MachineSlotsViewModel>>(await response.Content.ReadAsStringAsync(), options);

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(machineSlots);
            Assert.NotEmpty(machineSlots);
            client.Dispose();
        }

       [Fact]
        public async void Given_GetSalesByMachineId_When_Call_API_Then_Should_Return_Result()
        {
            //arrange
            var client = testServer.CreateClient();
            var urlEndPoint = "GetSales";
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            //act
            var response = await client.GetAsync($"{_urlController}{urlEndPoint}");
            var sales = JsonSerializer.Deserialize<List<SalesViewModel>>(await response.Content.ReadAsStringAsync(), options);

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(sales);
            Assert.NotEmpty(sales);
            client.Dispose();
        }
        
        [Fact]
        public async void Given_GetProductStockByProductId_When_Call_API_Then_Should_Return_Result()
        {
            //arrange
            var client = testServer.CreateClient();
            var urlEndPoint = "GetProductStockByProductId";
            var productId = 1;
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            //act
            var response = await client.GetAsync($"{_urlController}{urlEndPoint}/{productId}");
            var productStock = JsonSerializer.Deserialize<ProductStockViewModel>(await response.Content.ReadAsStringAsync(), options);

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(productStock);
            Assert.Equal(productId, productStock.Id);
            client.Dispose();
        }


        [Fact]
        public async void Given_CreateSale_When_Call_API_Then_Should_Create_And_Return_no_Errors()
        {
            //arrange
            var client = testServer.CreateClient();
            var urlEndPoint = "CreateSale";
            var sale = new SalesViewModel
            {
                Id = 0, 
                ProductId = 1,
                ProductPrice = new decimal(1.00),
                CreatedOn = System.DateTime.UtcNow
            };
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var jsonData = JsonSerializer.Serialize(sale);

            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");

            //act
            var response = await client.PostAsync($"{_urlController}{urlEndPoint}", data);

            var result = await response.Content.ReadAsStringAsync();
            
            var operationResult = JsonSerializer.Deserialize<Result>(result, options);

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(operationResult);
            Assert.True(!operationResult.HasErrors);
            client.Dispose();
        }

        [Fact]
        public async void Given_UpdateMachine_When_Call_API_Then_Should_Update_And_Return_no_Errors()
        {
            //arrange
            var client = testServer.CreateClient();
            var urlEndPoint = "UpdateMachine";
            var machine = new MachineViewModel
            {
                Id = 1,
                MachineCurrencyId = 1,
                MachineLanguageId = 1,
                MaintenanceRequested = true,
                CreatedOn = System.DateTime.UtcNow
            };
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var jsonData = JsonSerializer.Serialize(machine);

            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");

            //act
            var response = await client.PutAsync($"{_urlController}{urlEndPoint}", data);

            var result = await response.Content.ReadAsStringAsync();

            var operationResult = JsonSerializer.Deserialize<Result>(result, options);

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(operationResult);
            Assert.True(!operationResult.HasErrors);
            client.Dispose();
        }
    }
}
