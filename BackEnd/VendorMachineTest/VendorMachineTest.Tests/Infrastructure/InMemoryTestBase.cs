using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VendorMachineTest.Data.Context;

namespace VendorMachineTest.Tests.Infrastructure
{
    public class InMemoryTestBase
    {
        protected VendorMachineContext VendorMachineContext;
        protected readonly TestServer testServer;

        public InMemoryTestBase()
        {
            var config = new ConfigurationBuilder().Build();

            var webHostBuilder = new WebHostBuilder()
                .UseEnvironment("Test")
                .UseConfiguration(config)
                .ConfigureTestServices(ConfigureTest)
                .UseStartup<TestStartup>();

            testServer = new TestServer(webHostBuilder);

            VendorMachineContext = testServer.Host.Services.GetService<VendorMachineContext>();

            InMemoryInitializer.Initialize(VendorMachineContext);
        }

        private void ConfigureTest(IServiceCollection services)
        {
            //insert mocks when needed
        }
    }
}
